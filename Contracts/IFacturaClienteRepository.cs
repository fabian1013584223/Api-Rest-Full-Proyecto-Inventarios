using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFacturaClienteRepository
    {
        IEnumerable<FacturaCliente> GetAllSaleBills(bool trackChanges);
        FacturaCliente GetSaleBill(Guid saleBillId, bool trackChanges);
        IEnumerable<FacturaCliente> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges);
        FacturaCliente GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges);
        void CreateSaleBillForUser(Guid usuarioId, FacturaCliente facVenta);
        void DeleteSaleBill(FacturaCliente facVenta);
    }
}
