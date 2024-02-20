using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MetodoPagoDTO
    {
        public Guid MetodoPagoId { get; init; }
        public string? Nombre { get; init; }
        public DateTime FechaPago { get; init;}
    }
}