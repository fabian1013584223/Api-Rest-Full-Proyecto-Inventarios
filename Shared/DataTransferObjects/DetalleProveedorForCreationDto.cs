namespace Shared.DataTransferObjects;

public record DetalleProveedorForCreationDto : DetalleForManipulationDto
{
	public IEnumerable<DetalleProveedorForCreationDto>? Facturas { get; init; }
}
