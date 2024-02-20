using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFacturaProveedorService
    {
        IEnumerable<FacturaProveedorDto> GetAllBuyBills(bool trackChanges);
        FacturaProveedorDto GetBuyBill(Guid Id, bool trackChanges);
        IEnumerable<FacturaProveedorDto> GetAllBuyBillsForSupplier(Guid proveedorId, bool trackChanges);
        FacturaProveedorDto GetBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        FacturaProveedorDto CreateBuyBillForSupplier(Guid proveedorId, FacturaProveedorForCreationDto facCompraForCreation, bool trackChanges);
        void DeleteBuyBillForSupplier(Guid proveedorId, Guid Id, bool trackChanges);
        void UpdateBuyBillForSupplier(Guid proveedorId, Guid id,
            FacturaProveedorForUpdateDto facCompraForUpdate, bool proveedorTrackChanges, bool facCompraTrackChanges);
        (FacturaProveedorForUpdateDto facCompraToPatch, FacturaProveedor facCompraEntity) GetFacturaCompraForPatch
            (Guid proveedorId, Guid id, bool proveedorTrackChanges, bool facCompraTrackChanges);
        void SaveChangesForPatch(FacturaProveedorForUpdateDto facCompraToPatch, FacturaProveedor facCompraEntity);
    }
}
