using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Producto
    {
        [Column("ProductoId")]
        [Key]
        public Guid ProductoId { get; set; }
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public string? Estado { get; set; }
        public string? Lugar { get; set; }
        [ForeignKey(nameof(Stock))]
        public Guid StockId { get; set; }
        public Stock? Stock { get; set; }

        [ForeignKey(nameof(Categoria))]
        public Guid IdCategoria { get; set; }
        public Categoria? Categoria{ get; set; }
        public ICollection<Precios>? HistoricoPrecios { get; set; }
        public ICollection<DetalleFacturaCliente>? DetalleFacturaCliente { get; set; }


    }
}
