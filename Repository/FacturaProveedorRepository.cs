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
    public class FacturaProveedorRepository : RepositoryBase<FacturaProveedor>, IFacturaProveedorRepository
    {
        public FacturaProveedorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public IEnumerable<FacturaProveedor> GetAllBuyBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Fecha)
                .ToList();

        public FacturaProveedor GetBuyBill(Guid FacturaCompraId, bool trackChanges) =>
            FindByCondition(c => c.FacturaCompraId.Equals(FacturaCompraId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<FacturaProveedor> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges) =>
            FindByCondition(e => e.IdProveedor.Equals(proveedorId), trackChanges)
            .OrderBy(e => e.Proveedores)
            .ToList();

        public FacturaProveedor GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.IdProveedor.Equals(proveedorId) && e.FacturaCompraId == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateBuyBillForSupplier(Guid proveedorId, FacturaProveedor facCompra)
        {
            facCompra.IdProveedor = proveedorId;
            Create(facCompra);
        }

        public void DeleteBuyBill(FacturaProveedor facCompra) => Delete(facCompra);
    }
}
