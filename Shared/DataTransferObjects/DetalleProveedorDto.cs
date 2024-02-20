namespace Shared.DataTransferObjects;

public record DetalleProveedorDto
{
    public Guid DetalleFacturaCompraId { get; init; }
    public float? ValorUnitario { get; init; }
    public int? Cantidad { get; init; }
    public float? IVA { get; init; }
    public float? ValorDescuento { get; init; }
    public Guid FacturaCompraId { get; init; }
}
