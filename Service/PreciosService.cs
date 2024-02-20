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
    internal sealed class PreciosService : IPreciosService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public PreciosService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<PrecioDTO> GetAllPriceHistories(bool trackChanges)
        {
            var historicoPrecios = _repository.HistoricoPrecios.GetAllPriceHistories(trackChanges);
            var historicoPreciosDTO = _mapper.Map<IEnumerable<PrecioDTO>>(historicoPrecios);

            return historicoPreciosDTO;
        }

        public PrecioDTO GetPriceHistory(Guid Id, bool trackChanges)
        {
            var historicoPrecios = _repository.HistoricoPrecios.GetPriceHistory(Id, trackChanges);
            if (historicoPrecios == null)
            {
                throw new HistoricoPreciosNotFoundException(Id);
            }

            var historicoPreciosDTO = _mapper.Map<PrecioDTO>(historicoPrecios);
            return historicoPreciosDTO;
        }

        public IEnumerable<PrecioDTO> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);

            if (producto is null)
            {
                throw new HistoricoPreciosNotFoundException(productoId);
            }
            var histPreciosFromDb = _repository.HistoricoPrecios.GetAllPriceHistoriesForProduct(productoId, trackChanges);
            var histPreciosDTO = _mapper.Map<IEnumerable<PrecioDTO>>(histPreciosFromDb);

            return histPreciosDTO;
        }

        public PrecioDTO GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(productoId);
            }
            var histPreciosDb = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, Id, trackChanges);
            if (histPreciosDb is null)
            {
                throw new HistoricoPreciosNotFoundException(Id);
            }
            var histPrecios = _mapper.Map<PrecioDTO>(histPreciosDb);
            return histPrecios;
        }

        public PrecioDTO CreatePriceHistoryForProduct(Guid productoId, PrecioForCreationDTO priceHistory, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var historicoPrecioEntity = _mapper.Map<Precios>(priceHistory);

            _repository.HistoricoPrecios.CreatePriceHistoryForProduct(productoId, historicoPrecioEntity);
            _repository.Save();

            var priceHistoryToReturn = _mapper.Map<PrecioDTO>(historicoPrecioEntity);
            return priceHistoryToReturn;
        }

        public void DeletePriceHistoryForProduct(Guid productoId, Guid priceHistoryId, bool trackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, trackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var priceHistory = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, priceHistoryId,
                trackChanges);
            if (priceHistory == null)
                throw new HistoricoPreciosNotFoundException(priceHistoryId);

            _repository.HistoricoPrecios.DeletePriceHistory(priceHistory);
            _repository.Save();
        }

        public void UpdatePriceHistoryForProduct(Guid productoId, Guid priceHistoryId, PrecioForUpdateDTO priceHistoryForUpdate, bool productoTrackChanges, bool histPreciosTrackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, productoTrackChanges);
            if (producto is null)
            {
                throw new ProductoNotFoundException(priceHistoryId);
            }

            var priceHistoryEntity = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, priceHistoryId, histPreciosTrackChanges);
            if (priceHistoryEntity is null)
            {
                throw new HistoricoPreciosNotFoundException(priceHistoryId);
            }

            _mapper.Map(priceHistoryForUpdate, priceHistoryEntity);
            _repository.Save();
        }

        public (PrecioForUpdateDTO histPreciosToPatch, Precios histPreciosEntity) GetHistoricoPreciosForPatch(Guid productoId, Guid id, bool productoTrackChanges, bool historicoPrecioTrackChanges)
        {
            var producto = _repository.Producto.GetProduct(productoId, productoTrackChanges);
            if (producto is null)
                throw new ProductoNotFoundException(productoId);

            var historicoPrecioEntity = _repository.HistoricoPrecios.GetPriceHistoryForProduct(productoId, id, historicoPrecioTrackChanges);

            if (historicoPrecioEntity is null)
                throw new HistoricoPreciosNotFoundException(productoId);

            var historicoPrecioToPatch = _mapper.Map<PrecioForUpdateDTO>(historicoPrecioEntity);
            return (historicoPrecioToPatch, historicoPrecioEntity);
        }

        public void SaveChangesForPatch(PrecioForUpdateDTO historicoPrecioToPatch, Precios historicoPrecioEntity)
        {
            _mapper.Map(historicoPrecioToPatch, historicoPrecioEntity);
            _repository.Save();
        }
    }
}
