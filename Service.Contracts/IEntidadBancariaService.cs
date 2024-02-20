using Shared.DataTransferObjects;
using Entities.Models;


namespace Service.Contracts;

public interface IEntidadBancariaService
{
    Task<IEnumerable<EntidadBancariaDTO>> GetAllEntidadBancariaAsync(Guid MetodoPagoId, bool trackChanges);
    Task<EntidadBancariaDTO> GetEntidadBancariaByIdAsync(Guid MetodoPagoId, Guid EntidadBancariaId, bool trackChanges);
    Task<EntidadBancariaDTO> CreateEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, EntidadBancariaForCreationDTO entidadBancariaForCreation, bool trackChanges);
    Task DeleteEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, Guid EntidadBancariaId, bool trackChanges);
    Task UpdateEntidadBancariaForMetodoPagoAsync(Guid MetodoPagoId, Guid EntidadBancariaId, EntidadBancariaForUpdateDTO entidadBancariaForUpdate, bool compTrackChanges, bool empTrackChanges);
    Task<(EntidadBancariaForUpdateDTO entidadBancariaToPatch, EntidadBancaria entidadBancariaEntity)> GetEntidadBancariaForPatchAsync(
    Guid MetodoPagoId, Guid EntidadBancariaId, bool compTrackChanges, bool empTrackChanges);
    Task SaveChangesForPatchAsync(EntidadBancariaForUpdateDTO entidadBancariaToPatch, EntidadBancaria entidadBancariaEntity);
}
