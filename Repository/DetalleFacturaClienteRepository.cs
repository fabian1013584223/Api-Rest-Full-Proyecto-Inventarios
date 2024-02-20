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
    public class DetalleFacturaClienteRepository : RepositoryBase<DetalleFacturaCliente>, IDetFacturaClienteRepository
    {
        public DetalleFacturaClienteRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }


        public IEnumerable<DetalleFacturaCliente> GetAllDetSaleBills(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.FacturaVentaId)
                .ToList();

        public DetalleFacturaCliente GetDetSaleBill(Guid FacturaVentaId, bool trackChanges) =>
            FindByCondition(c => c.FacturaVentaId.Equals(FacturaVentaId), trackChanges)
            .SingleOrDefault();

    }
}
