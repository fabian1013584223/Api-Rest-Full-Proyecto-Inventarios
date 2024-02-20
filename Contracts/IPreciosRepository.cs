using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPreciosRepository
    {

        IEnumerable<Precios> GetAllPriceHistories(bool trackChanges);
        Precios GetPriceHistory(Guid priceHistoryId, bool trackChanges);
        IEnumerable<Precios> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges);
        Precios GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges);
        void CreatePriceHistoryForProduct(Guid productoId, Precios historicoPrecio);
        void DeletePriceHistory(Precios historicoPrecio);
    }
}
