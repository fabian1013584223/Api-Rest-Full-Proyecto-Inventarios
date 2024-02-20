using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IProveedorService
    {
        IEnumerable<ProveedorDto> GetAllSuppliers(bool trackChanges);
        ProveedorDto GetSupplier(Guid Id, bool trackChanges);
        ProveedorDto CreateSupplier(ProveedorForCreationDto supplier);
        IEnumerable<ProveedorDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges);
        (IEnumerable<ProveedorDto> proveedores, string ids) CreateSupplierCollection
            (IEnumerable<ProveedorForCreationDto> supplierCollection);
        void DeleteSupplier(Guid supplierId, bool trackChanges);
        void UpdateSupplier(Guid supplierId, ProveedorForUpdateDto supplierForUpdate, bool trackChanges);
    }
}
