namespace Shared.DataTransferObjects;

public record DetalleProveedorForUpdateDto : DetalleForManipulationDto
{
	public IEnumerable<FacturaForCreationDto>? Facturas { get; init; }
}
