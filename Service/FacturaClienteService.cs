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
    internal sealed class FacturaClienteService : IFacturaClienteService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public FacturaClienteService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<FacturaDto> GetAllSaleBills(bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetAllSaleBills(trackChanges);
            var facturaVentaDTO = _mapper.Map<IEnumerable<FacturaDto>>(facturaVenta);

            return facturaVentaDTO;
        }

        public FacturaDto GetSaleBill(Guid Id, bool trackChanges)
        {
            var facturaVenta = _repository.FacturaVenta.GetSaleBill(Id, trackChanges);
            if (facturaVenta == null)
            {
                throw new FacturaVentaNotFoundException(Id);
            }

            var facturaVentaDTO = _mapper.Map<FacturaDto>(facturaVenta);
            return facturaVentaDTO;
        }

        public IEnumerable<FacturaDto> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);

            if (usuario is null)
            {
                throw new UsuarioNotFoundException(usuarioId);
            }
            var facVentasFromDb = _repository.FacturaVenta.GetAllSaleBillsForUser(usuarioId, trackChanges);
            var facVentasDTO = _mapper.Map<IEnumerable<FacturaDto>>(facVentasFromDb);

            return facVentasDTO;
        }

        public FacturaDto GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);
            if (usuario is null)
            {
                throw new UsuarioNotFoundException(usuarioId);
            }
            var facVentaDb = _repository.FacturaVenta.GetSaleBillForUser(usuarioId, Id, trackChanges);
            if (facVentaDb is null)
            {
                throw new FacturaVentaNotFoundException(Id);
            }
            var facVenta = _mapper.Map<FacturaDto>(facVentaDb);
            return facVenta;
        }

        public FacturaDto CreateSaleBillForUser(Guid usuarioId, FacturaForCreationDto facVentaForCreation, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);
            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioId);

            var facVentaEntity = _mapper.Map<FacturaCliente>(facVentaForCreation);

            _repository.FacturaVenta.CreateSaleBillForUser(usuarioId, facVentaEntity);
            _repository.Save();

            var facVentaToReturn = _mapper.Map<FacturaDto>(facVentaEntity);
            return facVentaToReturn;
        }

        public void DeleteSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, trackChanges);
            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioId);

            var facVentaForUsuario = _repository.FacturaVenta.GetSaleBillForUser(usuarioId, Id,
            trackChanges);
            if (facVentaForUsuario is null)
                throw new FacturaVentaNotFoundException(Id);

            _repository.FacturaVenta.DeleteSaleBill(facVentaForUsuario);
            _repository.Save();
        }

        public void UpdateSaleBillForUser(Guid usuarioId, Guid id, FacturaForUpdateDto facVentaForUpdate, bool usuarioTrackChanges, bool facVentaTrackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, usuarioTrackChanges);
            if (usuario is null)
            {
                throw new UsuarioNotFoundException(usuarioId);
            }

            var facVentaEntity = _repository.FacturaVenta.GetSaleBillForUser(usuarioId, id, facVentaTrackChanges);
            if (facVentaEntity is null)
            {
                throw new FacturaVentaNotFoundException(id);
            }

            _mapper.Map(facVentaForUpdate, facVentaEntity);
            _repository.Save();
        }

        public (FacturaForUpdateDto facVentaToPatch, FacturaCliente facVentaEntity) GetFacturaVentaForPatch(Guid usuarioId, Guid id, bool usuarioTrackChanges, bool facVentaTrackChanges)
        {
            var usuario = _repository.Usuario.GetUser(usuarioId, facVentaTrackChanges);
            if (usuario is null)
                throw new UsuarioNotFoundException(usuarioId);

            var facVentaEntity = _repository.FacturaVenta.GetSaleBillForUser(usuarioId, id, facVentaTrackChanges);

            if (facVentaEntity is null)
                throw new FacturaVentaNotFoundException(usuarioId);

            var facVentaToPatch = _mapper.Map<FacturaForUpdateDto>(facVentaEntity);
            return (facVentaToPatch, facVentaEntity);
        }

        public void SaveChangesForPatch(FacturaForUpdateDto facVentaToPatch, FacturaCliente facVentaEntity)
        {
            _mapper.Map(facVentaToPatch, facVentaEntity);
            _repository.Save();
        }
    }
}
