using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFacturaProveedorRepository
    {

        IEnumerable<FacturaProveedor> GetAllBuyBills(bool trackChanges);
        FacturaProveedor GetBuyBill(Guid buyBillId, bool trackChanges);
        IEnumerable<FacturaProveedor> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges);
        FacturaProveedor GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        void CreateBuyBillForSupplier(Guid proveedorId, FacturaProveedor facCompra);
        void DeleteBuyBill(FacturaProveedor facCompra);
    }
}
