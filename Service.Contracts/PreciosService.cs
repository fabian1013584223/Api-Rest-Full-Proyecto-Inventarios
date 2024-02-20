using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPreciosService
    {
        IEnumerable<PrecioDTO> GetAllPriceHistories(bool trackChanges);
        PrecioDTO GetPriceHistory(Guid Id, bool trackChanges);
        IEnumerable<PrecioDTO> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges);
        PrecioDTO GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges);
        PrecioDTO CreatePriceHistoryForProduct(Guid productoId, PrecioForCreationDTO priceHistory, bool trackChanges);
        void DeletePriceHistoryForProduct(Guid productoId, Guid priceHistoryId, bool trackChanges);
        void UpdatePriceHistoryForProduct(Guid productoId, Guid priceHistoryId,
            PrecioForUpdateDTO priceHistoryForUpdate, bool productoTrackChanges, bool histPreciosTrackChanges);
        (PrecioForUpdateDTO histPreciosToPatch, Precios histPreciosEntity) GetHistoricoPreciosForPatch
            (Guid productoId, Guid Id, bool productoTrackChanges, bool histPreciosTrackChanges);
        void SaveChangesForPatch(PrecioForUpdateDTO histPreciosToPatch, Precios histPreciosEntity);
    }
}
