using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record PrecioForManipulationDTO
    {
        [Required(ErrorMessage = "Precio is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public Guid PrecioId { get; init; }

        [Range(18, float.MaxValue, ErrorMessage = "Precio is required and it can't be lower than 18")]
        public float PrecioVenta { get; init; }

        [Required(ErrorMessage = "Precio is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public float PrecioCompra { get; init; }
    }
}
