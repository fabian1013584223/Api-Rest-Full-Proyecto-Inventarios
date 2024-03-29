﻿using AutoMapper;
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
    internal sealed class DetProveedorService : IDetFacturaProveedorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public DetProveedorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<DetalleProveedorDto> GetAllDetBuyBills(bool trackChanges)
        {
            var dFacturaCompra = _repository.DetFacturaProveedor.GetAllDetBuyBills(trackChanges);
            var dFacturaCompraDTO = _mapper.Map<IEnumerable<DetalleProveedorDto>>(dFacturaCompra);

            return dFacturaCompraDTO;
        }

        public IEnumerable<DetalleProveedorDto> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);

            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }
            var detalleFacturaComprasFromDb = _repository.DetFacturaProveedor.GetAllDetBuyBillsByBuyBill(facturaCompraId, trackChanges);
            var detalleFacturaComprasDTO = _mapper.Map<IEnumerable<DetalleProveedorDto>>(detalleFacturaComprasFromDb);

            return detalleFacturaComprasDTO;
        }

        public IEnumerable<DetalleProveedorDto> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }
            var detalleFacturaCompraFromDb = _repository.DetFacturaProveedor.GetAllDetBuyBillsByProduct(productoId, trackChanges);
            var detalleFacturaCompraDTO = _mapper.Map<IEnumerable<DetalleProveedorDto>>(detalleFacturaCompraFromDb);

            return detalleFacturaCompraDTO;
        }

        public IEnumerable<DetalleProveedorDto> GetAllDetBuyBillsForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);

            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var detalleFacturaComprasFromDb = _repository.DetFacturaProveedor.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, trackChanges);
            var detalleFacturaComprasDTO = _mapper.Map<IEnumerable<DetalleProveedorDto>>(detalleFacturaComprasFromDb);

            return detalleFacturaComprasDTO;
        }
        public DetalleProveedorDto GetDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);
            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var perdProdloyeDb = _repository.DetFacturaProveedor.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, trackChanges);
            if (perdProdloyeDb is null)
            {
                throw new DetalleFacturaCompraNotFoundException(facturaCompraId, productoId);
            }
            var detalleFacturaCompra = _mapper.Map<DetalleProveedorDto>(perdProdloyeDb);
            return detalleFacturaCompra;
        }

        public DetalleProveedorDto CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleProveedorForCreationDto detalleFacturaCompraForCreation, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);
            if (facturaCompra is null)
                throw new FacturaCompraNotFoundException(facturaCompraId);


            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var detalleFacturaCompraEntity = _mapper.Map<DetalleFacturaProveedor>(detalleFacturaCompraForCreation);

            _repository.DetFacturaProveedor.CreateDetBuyBillForBuyBillAndProduct(facturaCompraId, productoId, detalleFacturaCompraEntity);
            _repository.Save();

            var detalleFacturaCompraToReturn = _mapper.Map<DetalleProveedorDto>(detalleFacturaCompraEntity);
            return detalleFacturaCompraToReturn;
        }

        public void DeleteDetBuyBillForBuyBill(Guid facturaCompraId, Guid productoId, bool trackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, trackChanges);
            if (facturaCompra is null)
                throw new FacturaCompraNotFoundException(facturaCompraId);

            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var detalleFacturaCompraForBuyBill = _repository.DetFacturaProveedor.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, trackChanges);
            if (detalleFacturaCompraForBuyBill is null)
                throw new DetalleFacturaCompraNotFoundException(facturaCompraId, productoId);
            _repository.DetFacturaProveedor.DeleteDetBuyBill(detalleFacturaCompraForBuyBill);
            _repository.Save();
        }

        public void UpdateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleProveedorForUpdateDto detalleFacturaCompraForUpdate, bool perdTrackChanges, bool prodTrackChanges, bool perdProdTrackChanges)
        {
            var facturaCompra = _repository.FacturaCompra.GetBuyBill(facturaCompraId, perdTrackChanges);
            if (facturaCompra is null)
            {
                throw new FacturaCompraNotFoundException(facturaCompraId);
            }

            var producto = _repository.Producto.GetProduct(productoId, prodTrackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }

            var detalleFacturaCompraEntity = _repository.DetFacturaProveedor.GetDetBuyBillByBuyBillAndProduct(facturaCompraId, productoId, perdProdTrackChanges);
            if (detalleFacturaCompraEntity is null)
            {
                throw new DetalleFacturaCompraNotFoundException(facturaCompraId, productoId);
            }

            _mapper.Map(detalleFacturaCompraForUpdate, detalleFacturaCompraEntity);
            _repository.Save();
        }
    }
}
