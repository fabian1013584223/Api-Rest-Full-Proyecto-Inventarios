using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IDetFacturaProveedorService
    {
        IEnumerable<DetalleProveedorDto> GetAllDetBuyBills(bool trackChanges);

        IEnumerable<DetalleProveedorDto> GetAllDetBuyBillsByBuyBill(Guid facturaCompraId, bool trackChanges);
        IEnumerable<DetalleProveedorDto> GetAllDetBuyBillsByProduct(Guid productoId, bool trackChanges);

        IEnumerable<DetalleProveedorDto> GetAllDetBuyBillsForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges);
        DetalleProveedorDto GetDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, bool trackChanges);

        DetalleProveedorDto CreateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId, DetalleProveedorForCreationDto facturaCompraProductoForCreation, bool trackChanges);
        void DeleteDetBuyBillForBuyBill(Guid facturaCompraId, Guid productoId, bool trackChanges);
        //    void UpdateDetBuyBillForBuyBillAndProduct(Guid facturaCompraId, Guid productoId,
        //        DetalleForUpdateDto facturaCompraProductoForUpdate, bool perdProdTrackChanges, bool perdTrackChanges, bool prodTrackChanges);
        //}
    }
}