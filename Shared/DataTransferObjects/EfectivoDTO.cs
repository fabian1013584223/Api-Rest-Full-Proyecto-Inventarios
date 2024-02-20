using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record  EfectivoDTO
    {
        public Guid EfectivoId { get; init; }
        public float ValorPago { get; init; }
        public Guid MetodoPagoId { get; init; }
    }
}