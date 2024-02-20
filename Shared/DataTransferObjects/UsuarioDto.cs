
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UsuarioDto
    {
        public Guid IdUsuario { get; init; }
        public string? Nombre { get; init; }
        public string? Direccion { get; init; }
        public string? Contraseña { get; init; }
        public string? Apellido { get; init; }
        public string? Correo { get; init; }
        public long NumeroDocumento { get; init; }
        public long Contacto { get; init; }
        public string? Pais { get; init; }
    }
}