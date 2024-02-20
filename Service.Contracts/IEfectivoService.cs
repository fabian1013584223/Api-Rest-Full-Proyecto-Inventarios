using Shared.DataTransferObjects;
using Entities.Models;


namespace Service.Contracts;

public interface IEfectivoService
{
    Task<IEnumerable<EfectivoDTO>> GetAllEfectivoAsync(Guid MetodoPagoId, bool trackChanges);
    Task<EfectivoDTO> GetEfectivoByIdAsync(Guid MetodoPagoId, Guid EfectivoId, bool trackChanges);
    Task<EfectivoDTO> CreateEfectivoForMetodoPagoAsync(Guid MetodoPagoId, EfectivoForCreationDTO efectivoForCreation, bool trackChanges);
    Task DeleteEfectivoForMetodoPagoAsync(Guid MetodoPagoId, Guid EfectivoId, bool trackChanges);
    Task UpdateEfectivoForMetodoPagoAsync(Guid MetodoPagoId, Guid EfectivoId, EfectivoForUpdateDTO efectivoForUpdate, bool compTrackChanges, bool empTrackChanges);
    Task<(EfectivoForUpdateDTO efectivoToPatch, Efectivo efectivoEntity)> GetEfectivoForPatchAsync(
    Guid MetodoPagoId, Guid EfectivoId, bool compTrackChanges, bool empTrackChanges);
    Task SaveChangesForPatchAsync(EfectivoForUpdateDTO efectivoToPatch, Efectivo efectivoEntity);
}
