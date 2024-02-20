namespace Shared.DataTransferObjects;

public record DetalleForUpdateDto : DetalleForManipulationDto
{
	public IEnumerable<FacturaForCreationDto>? Facturas { get; init; }
}
