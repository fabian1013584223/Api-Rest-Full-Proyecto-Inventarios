using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record StockDTO
    {
        public Guid StockId { get; init; }
        public int CantidadReal { get; init; }
        public int CantidadIdeal { get; init; }
        public int CantidadMinima { get; init; }
        public int CantidadAlarma { get; init; }
        public DateTime FechaIngreso { get; init; }

    }
}


    