using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record EntidadBancariaDTO
    {
        public Guid EntidadBancariaId { get; init; }
        public string? Nombre { get; init; }
        public float Monto { get; init; }
        public Guid MetodoPagoId { get; init; }
    }
}
