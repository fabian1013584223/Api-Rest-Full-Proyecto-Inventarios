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
    public class FacturaClienteRepository : RepositoryBase<FacturaCliente>, IFacturaClienteRepository
    {
        public FacturaClienteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<FacturaCliente> GetAllSaleBills(bool trackChanges) =>
                    FindAll(trackChanges)
                        .OrderBy(c => c.FacturaVentaId)
                        .ToList();

        public FacturaCliente GetSaleBill(Guid FacturaVentaId, bool trackChanges) =>
            FindByCondition(c => c.FacturaVentaId.Equals(FacturaVentaId), trackChanges)
            .SingleOrDefault();

        public IEnumerable<FacturaCliente> GetAllSaleBillsForUser(Guid usuarioId, bool trackChanges) =>
            FindByCondition(e => e.ClienteId.Equals(usuarioId), trackChanges)
            .OrderBy(e => e.Clientes)
            .ToList();

        public FacturaCliente GetSaleBillForUser(Guid usuarioId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.ClienteId.Equals(usuarioId) && e.FacturaVentaId == (Id), trackChanges)
            .SingleOrDefault();

        public void CreateSaleBillForUser(Guid usuarioId, FacturaCliente facVenta)
        {
            facVenta.ClienteId = usuarioId;
            Create(facVenta);
        }

        public void DeleteSaleBill(FacturaCliente facVenta) => Delete(facVenta);

    }
}
