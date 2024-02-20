using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public sealed class StockRepository : RepositoryBase<Stock>, IStockRepository
    {
        public StockRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Stock>> GetAllStocksAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .OrderBy(c => c.CantidadReal)
            .ToListAsync();

        public async Task<Stock> GetStockByIdAsync(Guid StockId, bool trackChanges) =>
            await FindByCondition(c => c.StockId.Equals(StockId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateStock(Stock stock) => Create(stock);

        public async Task<IEnumerable<Stock>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
            await FindByCondition(x => ids.Contains(x.StockId), trackChanges)
            .ToListAsync();


        public void DeleteStock(Stock stock) => Delete(stock);
    }
}