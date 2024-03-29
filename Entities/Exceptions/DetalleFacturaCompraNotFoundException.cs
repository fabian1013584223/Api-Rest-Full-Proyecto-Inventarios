﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class DetalleFacturaCompraNotFoundException : NotFoundException
    {
        public DetalleFacturaCompraNotFoundException(Guid IdDetalleacturaCompra, Guid productoId)
           : base($"El detalle de factura de compra con el Id: {IdDetalleacturaCompra} no existe en la Base de Datos.") { }
    }
}
