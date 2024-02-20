using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models; 

namespace Contracts
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllStocksAsync(bool trackChanges);
        Task<Stock> GetStockByIdAsync(Guid stockId, bool trackChanges);
        void CreateStock(Stock stock); 
        Task<IEnumerable<Stock>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        void DeleteStock(Stock stock);
    }
}
