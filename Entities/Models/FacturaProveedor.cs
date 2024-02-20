using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class FacturaProveedor
    {
        [Column("FacturaCompraId")]
        [Key]
        public Guid FacturaCompraId { get; set; }

        [Required(ErrorMessage = "Fecha  es un campo requerido.")]
        public DateTime? Fecha { get; set; }

        public Guid IdProveedor { get; set; }
        public Proveedor? Proveedores { get; set; }

    }
}
