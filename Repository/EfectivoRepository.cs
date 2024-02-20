using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal sealed class EfectivoRepository : RepositoryBase<Efectivo>, IEfectivoRepository
    {
        public EfectivoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        //PrecioconProducto
        public async Task<IEnumerable<Efectivo>> GetAllEfectivoAsync(Guid MetodoPagoId, bool trackChanges) =>
            await FindByCondition(e => e.MetodoPagoId.Equals(MetodoPagoId), trackChanges)
            .OrderBy(e => e.MetodoPagoId)
            .ToListAsync();
        public async Task<Efectivo> GetEfectivoByIdAsync(Guid MetodoPagoId, Guid EfectivoId, bool trackChanges) =>
            await FindByCondition(e => e.MetodoPagoId.Equals(MetodoPagoId) && e.EfectivoId.Equals(EfectivoId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateEfectivoForMetodoPago(Guid MetodoPagoId, Efectivo efectivo)
        {
            efectivo.MetodoPagoId = MetodoPagoId;
            Create(efectivo);
        }

        public void DeleteEfectivo(Efectivo efectivo) => Delete(efectivo);
    }
}

