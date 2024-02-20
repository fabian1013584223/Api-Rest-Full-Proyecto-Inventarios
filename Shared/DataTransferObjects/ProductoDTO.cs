using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProductoDTO
    {
        public Guid ProductoId { get; init; }
        public string? Nombre { get; init; }
        public int Cantidad { get; init; }
        public float Precio { get; init; }
        public string? Estado { get; init; }
        public string? Lugar { get; init; }
        public Guid StockId { get; init; }
        public Guid IdCategoria { get; init; }
    }
}

