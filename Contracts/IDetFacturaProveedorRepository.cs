using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDetFacturaProveedorRepository
    {
        IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBills(bool trackChanges);
        IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges);
        IEnumerable<DetalleFacturaProveedor> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges);
        DetalleFacturaProveedor GetDetBuyBillByBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges);
        void CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleFacturaProveedor detalleFacturaCompra);
        void DeleteDetBuyBill(DetalleFacturaProveedor detalleFacturaCompra);
    }
}