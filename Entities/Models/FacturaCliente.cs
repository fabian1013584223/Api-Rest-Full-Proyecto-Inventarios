using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class FacturaCliente
    {
        [Column("FacturaVentaId")]
        [Key]
        public Guid FacturaVentaId { get; set; }

        [Required(ErrorMessage = "Fecha es un campo requerido.")]
        public DateTime? Fecha { get; set; }

        [ForeignKey("ClienteId")]
        public Guid ClienteId { get; set; }

        public Cliente?Clientes { get; set; }

        public ICollection<MetodoPago>? MetodosPago { get; set; }
    }
}
