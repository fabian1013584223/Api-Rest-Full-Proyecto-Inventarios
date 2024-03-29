﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DetalleFacturaCliente
    {
        [Column("DetalleFacturaVentaID")]
        [Key]
        public Guid DetalleFacturaVentaID { get; set; }

        [Required(ErrorMessage = "ValorUnitario es un campo requerido.")]
        public float ValorUnitario { get; set; }

        [Required(ErrorMessage = "Cantidad es un campo requerido.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "IVA es un campo requerido.")]
        public float IVA { get; set; }

        [Required(ErrorMessage = "ValorDescuento es un campo requerido.")]
        public float ValorDescuento { get; set; }


        [ForeignKey(nameof(Producto))]
        public Guid ProductoId { get; set; }
        public Producto? Producto { get; set; }

        [ForeignKey(nameof(FacturaCliente))]
        public Guid FacturaVentaId { get; set; }
        public FacturaCliente? FacturasVenta { get; set; }
    }
}
