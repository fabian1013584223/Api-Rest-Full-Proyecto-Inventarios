﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DetalleFacturaProveedor
    {
        [Column("DetalleacturaCompraId")]
        [Key]
        public Guid DetalleFacturaCompraId { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public float ValorUnitario { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public float IVA { get; set; }

        [Required(ErrorMessage = "Este es un campo requerido")]
        public float ValorDescuento { get; set; }

        [ForeignKey(nameof(FacturaCompra))]
        public Guid FacturaCompraId { get; set; }
        public FacturaProveedor? FacturaCompra { get; set; }

        [ForeignKey(nameof(Producto))]
        public Guid ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
