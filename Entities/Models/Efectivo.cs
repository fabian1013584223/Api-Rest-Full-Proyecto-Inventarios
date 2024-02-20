using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Entities.Models
{
    public class Efectivo
    {
        [Column("EfectivoId")]
        [Key]
        public Guid EfectivoId { get; set; }
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public float ValorPago { get; set; }
        //[Required(ErrorMessage = "Company address is a required field.")]
        //[MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public Guid MetodoPagoId { get; set; }
        public MetodoPago? MetodoPago { get; set; }
    }
}