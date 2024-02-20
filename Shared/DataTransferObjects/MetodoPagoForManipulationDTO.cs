using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public abstract record MetodoPagoForManipulationDTO
    {
        [Required(ErrorMessage = "Metodo de pago name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Name { get; init; }

    }
}
