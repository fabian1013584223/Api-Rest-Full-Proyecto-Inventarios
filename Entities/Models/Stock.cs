using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Stock
    {
        [Column("StockId")]
        [Key]
        public Guid StockId { get; set; }
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public int CantidadReal { get; set; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public int CantidadIdeal { get; set; }
        public int CantidadMinima { get; set; }
        public int CantidadAlarma { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ICollection<Producto>? Productos{ get; set; }
    }
}
