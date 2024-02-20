using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ClienteDto
    {
        public Guid ClienteId { get; init; }
        public string? Numerodocumento { get; init; }
        public string? Tipodocumento { get; init; }
        public string? Nombre { get; init; }
        public string? Apellido { get; init; }
        public string? Correo { get; init; }
        public long? Contacto { get; init; }
        public Guid UsuarioId { get; init; }
    }
}
