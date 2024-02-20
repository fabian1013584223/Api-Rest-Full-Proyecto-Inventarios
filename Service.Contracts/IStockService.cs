using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IStockService
{
    Task<IEnumerable<StockDTO>> GetAllStocksAsync(bool trackChanges);
    Task<StockDTO> GetStockByIdAsync(Guid stockId, bool trackChanges);
    Task<StockDTO> CreateStockAsync(StockForCreationDTO stock);
    Task<IEnumerable<StockDTO>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
    Task<(IEnumerable<StockDTO> stocks, string ids)> CreateStockCollectionAsync
            (IEnumerable<StockForCreationDTO> stockCollection);
    Task DeleteStockAsync(Guid stockId, bool trackChanges);
    Task UpdateStockAsync(Guid stockId, StockForUpdateDTO stockForUpdate, bool trackChanges);
}

