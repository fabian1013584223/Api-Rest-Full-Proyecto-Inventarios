using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record FacturaProveedorDto
{
    public Guid FacturaCompraId { get; set; }
    public DateTime? Fecha { get; set; }
}