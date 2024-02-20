namespace Shared.DataTransferObjects;

public record DetalleDto
{
    public Guid DetalleFacturaVentaID { get; init; }
    public float? ValorUnitario { get; init; }
    public int? Cantidad { get; init; }
    public float? IVA { get; init; }
    public float? ValorDescuento { get; init; }
    public Guid FacturaVentaId { get; init; }
}
