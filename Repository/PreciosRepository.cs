using Contracts;
using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PreciosRepository : RepositoryBase<Precios>, IPreciosRepository
    {
        public PreciosRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

     

        public IEnumerable<Precios> GetAllPriceHistories(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.IdHistoricoPrecios)
                .ToList();

        public Precios GetPriceHistory(Guid IdHistoricoPrecios, bool trackChanges) =>
            FindByCondition(c => c.IdHistoricoPrecios.Equals(IdHistoricoPrecios), trackChanges)
            .SingleOrDefault();

        public IEnumerable<Precios> GetAllPriceHistoriesForProduct(Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId), trackChanges)
            .OrderBy(e => e.Producto)
            .ToList();

        public Precios GetPriceHistoryForProduct(Guid productoId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId) && e.IdHistoricoPrecios == (Id), trackChanges)
            .SingleOrDefault();

        public void CreatePriceHistoryForProduct(Guid productoId, Precios historicoPrecio)
        {
            historicoPrecio.ProductoId = productoId;
            Create(historicoPrecio);
        }

        public void DeletePriceHistory(Precios historicoPrecio) => Delete(historicoPrecio);
    }
}
