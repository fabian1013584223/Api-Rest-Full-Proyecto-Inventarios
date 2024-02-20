using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class FacturaProveedorService : IFacturaProveedorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FacturaProveedorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
      

        public IEnumerable<FacturaProveedorDto> GetAllBuyBills(bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetAllBuyBills(trackChanges);
            var facturaCompraDTO = _mapper.Map<IEnumerable<FacturaProveedorDto>>(facturaCompra);

            return facturaCompraDTO;
        }

        public FacturaProveedorDto GetBuyBill(Guid Id, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(Id, trackChanges);
            if (facturaCompra == null)
            {
                throw new FacturaCompraNotFoundException(Id);
            }

            var facturaCompraDTO = _mapper.Map<FacturaProveedorDto>(facturaCompra);
            return facturaCompraDTO;
        }

        public IEnumerable<FacturaProveedorDto> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);

            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }
            var facComprasFromDb = _repository.FacturaCompra.GetAllBuyBillsForSupplier(proveedorId, trackChanges);
            var facComprasDTO = _mapper.Map<IEnumerable<FacturaProveedorDto>>(facComprasFromDb);

            return facComprasDTO;
        }

        public FacturaProveedorDto GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }
            var facCompraDb = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, Id, trackChanges);
            if (facCompraDb is null)
            {
                throw new FacturaCompraNotFoundException(Id);
            }
            var facCompra = _mapper.Map<FacturaProveedorDto>(facCompraDb);
            return facCompra;
        }

        public FacturaProveedorDto CreateBuyBillForSupplier(Guid proveedorId, FacturaProveedorForCreationDto facCompraForCreation, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var facCompraEntity = _mapper.Map<FacturaProveedor>(facCompraForCreation);

            _repository.FacturaCompra.CreateBuyBillForSupplier(proveedorId, facCompraEntity);
            _repository.Save();

            var facCompraToReturn = _mapper.Map<FacturaProveedorDto>(facCompraEntity);
            return facCompraToReturn;
        }

        public void DeleteBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, trackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var facCompraForProveedor = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, Id,
            trackChanges);
            if (facCompraForProveedor is null)
                throw new FacturaCompraNotFoundException(Id);

            _repository.FacturaCompra.DeleteBuyBill(facCompraForProveedor);
            _repository.Save();
        }

        public void UpdateBuyBillForSupplier(Guid proveedorId, Guid id, FacturaProveedorForUpdateDto facCompraForUpdate, bool proveedorTrackChanges, bool facCompraTrackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, proveedorTrackChanges);
            if (proveedor is null)
            {
                throw new ProveedorNotFoundException(proveedorId);
            }

            var facCompraEntity = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, id, facCompraTrackChanges);
            if (facCompraEntity is null)
            {
                throw new FacturaCompraNotFoundException(id);
            }

            _mapper.Map(facCompraForUpdate, facCompraEntity);
            _repository.Save();
        }

        public (FacturaProveedorForUpdateDto facCompraToPatch, FacturaProveedor facCompraEntity) GetFacturaCompraForPatch(Guid proveedorId, Guid id, bool proveedorTrackChanges, bool facCompraTrackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(proveedorId, facCompraTrackChanges);
            if (proveedor is null)
                throw new ProveedorNotFoundException(proveedorId);

            var facCompraEntity = _repository.FacturaCompra.GetBuyBillForSupplier(proveedorId, id, facCompraTrackChanges);

            if (facCompraEntity is null)
                throw new FacturaCompraNotFoundException(proveedorId);

            var facCompraToPatch = _mapper.Map<FacturaProveedorForUpdateDto>(facCompraEntity);
            return (facCompraToPatch, facCompraEntity);
        }

        public void SaveChangesForPatch(FacturaProveedorForUpdateDto facCompraToPatch, FacturaProveedor facCompraEntity)
        {
            _mapper.Map(facCompraToPatch, facCompraEntity);
            _repository.Save();
        }
    }
}
