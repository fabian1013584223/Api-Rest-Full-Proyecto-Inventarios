namespace Shared.DataTransferObjects;

public record DetalleForCreationDto :DetalleForManipulationDto
{
	public IEnumerable<DetalleForCreationDto>? Facturas { get; init; }
}
