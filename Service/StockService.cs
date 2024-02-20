using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class StockService : IStockService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public StockService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDTO>> GetAllStocksAsync(bool trackChanges)
        {
            var stocks = await _repository.Stock.GetAllStocksAsync(trackChanges);
            var stocksDTO = _mapper.Map<IEnumerable<StockDTO>>(stocks);
            return stocksDTO;
        }

        public async Task<StockDTO> GetStockByIdAsync(Guid stockId, bool trackChanges)
        {
            var stock = await _repository.Stock.GetStockByIdAsync(stockId, trackChanges);
            //Check if the company is null
            if (stock is null)
                throw new StockNotFoundException(stockId);

            var stockDTO = _mapper.Map<StockDTO>(stock);

            return stockDTO;
        }
        //

        public async Task<StockDTO> CreateStockAsync(StockForCreationDTO stock)
        {
            var stockEntity = _mapper.Map<Stock>(stock);

            _repository.Stock.CreateStock(stockEntity);
            await _repository.SaveAsync();

            var stockToReturn = _mapper.Map<StockDTO>(stockEntity);

            return stockToReturn;
        }

        public async Task<IEnumerable<StockDTO>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();

            var stockEntities = await _repository.Stock.GetByIdsAsync(ids, trackChanges);
            if (ids.Count() != stockEntities.Count())
                throw new CollectionByIdsBadRequestException();

            var stocksToReturn = _mapper.Map<IEnumerable<StockDTO>>(stockEntities);

            return stocksToReturn;
        }

        public async Task<(IEnumerable<StockDTO> stocks, string ids)> CreateStockCollectionAsync
            (IEnumerable<StockForCreationDTO> stockCollection)
        {
            if (stockCollection is null)
                throw new ();

            var stockEntities = _mapper.Map<IEnumerable<Stock>>(stockCollection);
            foreach (var stock in stockEntities)
            {
                _repository.Stock.CreateStock(stock);
            }

            await _repository.SaveAsync();

            var stockCollectionToReturn = _mapper.Map<IEnumerable<StockDTO>>(stockEntities);
            var ids = string.Join(",", stockCollectionToReturn.Select(c => c.StockId));

            return (stocks: stockCollectionToReturn, ids: ids);
        }

        public async Task DeleteStockAsync(Guid stockId, bool trackChanges)
        {
            var stock = await _repository.Stock.GetStockByIdAsync(stockId, trackChanges);
            if (stock == null)
            {
                throw new StockNotFoundException(stockId);
            }

            _repository.Stock.DeleteStock(stock);
            await _repository.SaveAsync();

        }

        public async Task UpdateStockAsync(Guid stockId, StockForUpdateDTO stockForUpdate, bool trackChanches)
        {
            var stockEntity = await _repository.Stock.GetStockByIdAsync(stockId, trackChanches);
            if (stockEntity == null)
            
                throw new StockNotFoundException(stockId);
            
            _mapper.Map(stockForUpdate, stockEntity);
            await _repository.SaveAsync();

        }
    }
}