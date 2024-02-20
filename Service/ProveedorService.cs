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
    internal sealed class ProveedorService : IProveedorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProveedorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<ProveedorDto> GetAllSuppliers(bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetAllSuppliers(trackChanges);
            var proveedorDTO = _mapper.Map<IEnumerable<ProveedorDto>>(proveedor);

            return proveedorDTO;
        }

        public ProveedorDto GetSupplier(Guid Id, bool trackChanges)
        {
            var proveedor = _repository.Proveedor.GetSupplier(Id, trackChanges);
            if (proveedor == null)
            {
                throw new ProveedorNotFoundException(Id);
            }

            var proveedorDTO = _mapper.Map<ProveedorDto>(proveedor);
            return proveedorDTO;
        }
        public ProveedorDto CreateSupplier(ProveedorForCreationDto supplier)
        {
            var proveedorEntity = _mapper.Map<Proveedor>(supplier);

            _repository.Proveedor.CreateSupplier(proveedorEntity);
            _repository.Save();

            var supplierToReturn = _mapper.Map<ProveedorDto>(proveedorEntity);
            return supplierToReturn;
        }
        public IEnumerable<ProveedorDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            var supplierEntities = _repository.Proveedor.GetByIds(ids, trackChanges);
            if (ids.Count() != supplierEntities.Count())
                throw new CollectionByIdsBadRequestException();
            var suppliersToReturn = _mapper.Map<IEnumerable<ProveedorDto>>(supplierEntities);

            return suppliersToReturn;
        }
        public (IEnumerable<ProveedorDto> proveedores, string ids) CreateSupplierCollection
            (IEnumerable<ProveedorForCreationDto> supplierCollection)
        {
            if (supplierCollection is null)
                throw new ProveedorCollectionBadRequest();
            var supplierEntities = _mapper.Map<IEnumerable<Proveedor>>(supplierCollection);
            foreach (var supplier in supplierEntities)
            {
                _repository.Proveedor.CreateSupplier(supplier);
            }
            _repository.Save();
            var supplierCollectionToReturn =
            _mapper.Map<IEnumerable<ProveedorDto>>(supplierEntities);
            var ids = string.Join(",", supplierCollectionToReturn.Select(c => c.IdProveedor));
            return (suppliers: supplierCollectionToReturn, ids: ids);
        }
        public void DeleteSupplier(Guid supplierId, bool trackChanges)
        {
            var supplier = _repository.Proveedor.GetSupplier(supplierId, trackChanges);
            if (supplier == null)
                throw new ProveedorNotFoundException(supplierId);

            _repository.Proveedor.DeleteSupplier(supplier);
            _repository.Save();
        }
        public void UpdateSupplier(Guid supplierId, ProveedorForUpdateDto supplierForUpdate, bool trackChanges)
        {
            var supplierEntity = _repository.Proveedor.GetSupplier(supplierId, trackChanges);
            if (supplierEntity == null)
                throw new ProveedorNotFoundException(supplierId);

            _mapper.Map(supplierForUpdate, supplierEntity);
            _repository.Save();
        }
    }
}
