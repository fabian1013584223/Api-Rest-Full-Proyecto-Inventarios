using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record MetodoPagoForCreationDTO : MetodoPagoForManipulationDTO
    {
        public IEnumerable<EfectivoForCreationDTO>? Efectivos { get; init; }
        public IEnumerable<EntidadBancariaForCreationDTO>? EntidadBancarias { get; init; }
    }
}
