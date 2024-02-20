using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IFacturaClienteService
    {
        IEnumerable<FacturaDto> GetAllSaleBills(bool trackChanges);
        FacturaDto GetSaleBill(Guid Id, bool trackChanges);
        IEnumerable<FacturaDto> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges);
        FacturaDto GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges);
        FacturaDto CreateSaleBillForUser(Guid usuarioId, FacturaForCreationDto facVentaForCreation, bool trackChanges);
        void DeleteSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges);
        void UpdateSaleBillForUser(Guid usuarioId, Guid id,
            FacturaForUpdateDto facVentaForUpdate, bool usuarioTrackChanges, bool facVentaTrackChanges);
        (FacturaForUpdateDto facVentaToPatch, FacturaCliente facVentaEntity) GetFacturaVentaForPatch
            (Guid usuarioId, Guid id, bool usuarioTrackChanges, bool facVentaTrackChanges);
        void SaveChangesForPatch(FacturaForUpdateDto facVentaToPatch, FacturaCliente  facVentaEntity);
    }
}
