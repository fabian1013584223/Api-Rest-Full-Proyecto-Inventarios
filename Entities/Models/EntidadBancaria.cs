using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class EntidadBancaria
    {
        [Column("EntidadBancariaId")]
        [Key]
        public Guid EntidadBancariaId { get; set; }
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]

        public float Monto { get; set; }
        public Guid MetodoPagoId { get; set; }
        public MetodoPago? MetodoPago { get; set; }
    }
}
