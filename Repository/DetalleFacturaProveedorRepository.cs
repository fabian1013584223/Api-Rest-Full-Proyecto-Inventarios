using Contracts;
using Entities.Models;
using Repository.Configuration;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DetalleFacturaProvedorRepository : RepositoryBase<DetalleFacturaProveedor>, IDetFacturaProveedorRepository
    {
        public DetalleFacturaProvedorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaCompraId)
                .ToList();

        public IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges) =>
            FindByCondition(e => e.FacturaCompraId.Equals(facturaCompraId), trackChanges)
            .OrderBy(e => e.FacturaCompra)
            .ToList();


        public IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBillsByBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.FacturaCompraId.Equals(facturaCompraId) && e.ProductoId == (productoId), trackChanges)
            .OrderBy(e => e.FacturaCompra)
            .ToList();
        public DetalleFacturaProveedor GetDetBuyBillByBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.FacturaCompraId.Equals(facturaCompraId) && e.ProductoId == (productoId), trackChanges)
            .SingleOrDefault();


        public void CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleFacturaProveedor detalleFacturaCompra)
        {
            detalleFacturaCompra.FacturaCompraId = facturaCompraId;
            detalleFacturaCompra.ProductoId = productoId;
            Create(detalleFacturaCompra);
        }

        public void DeleteDetBuyBill(DetalleFacturaProveedor detalleFacturaCompra) => Delete(detalleFacturaCompra);

        public IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges) =>
            FindByCondition(e => e.ProductoId.Equals(productoId), trackChanges)
            .OrderBy(e => e.FacturaCompra)
            .ToList();

    }
}
