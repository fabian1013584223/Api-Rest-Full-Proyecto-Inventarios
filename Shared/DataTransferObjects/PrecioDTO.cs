using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record PrecioDTO
    {
        public Guid IdHistoricoPrecios { get; init; }
        public float PrecioCompra { get; init; }
        public float PrecioVenta { get; init; }
        public float PrecioDescuento { get; init; }
        public DateTime FechaDescuento { get; init; }
        public string? Estado { get; init; }
        public Guid PId { get; init; }
    }
}

