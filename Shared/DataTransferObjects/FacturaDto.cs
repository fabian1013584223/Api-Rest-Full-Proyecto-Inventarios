namespace Shared.DataTransferObjects;

public record FacturaDto
{
    public Guid FacturaVentaId { get; set; }
    public DateTime? Fecha { get; set; }
}