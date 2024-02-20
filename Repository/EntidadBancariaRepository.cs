using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    internal sealed class EntidadBancariaRepository : RepositoryBase<EntidadBancaria>, IEntidadBancariaRepository
    {
        public EntidadBancariaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        //PrecioconProducto
        public async Task<IEnumerable<EntidadBancaria>> GetAllEntidadBancariaAsync(Guid MetodoPagoId, bool trackChanges) =>
            await FindByCondition(e => e.MetodoPagoId.Equals(MetodoPagoId), trackChanges)
            .OrderBy(e => e.MetodoPagoId)
            .ToListAsync();
        public async Task<EntidadBancaria> GetEntidadBancariaByIdAsync(Guid MetodoPagoId, Guid EntidadBancariaId, bool trackChanges) =>
            await FindByCondition(e => e.MetodoPagoId.Equals(MetodoPagoId) && e.EntidadBancariaId.Equals(EntidadBancariaId), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateEntidadBancariaForMetodoPago(Guid MetodoPagoId, EntidadBancaria entidadBancaria)
        {
            entidadBancaria.MetodoPagoId = MetodoPagoId;
            Create(entidadBancaria);
        }

        public void DeleteEntidadBancaria(EntidadBancaria entidadBancaria) => Delete(entidadBancaria);
    }
}


