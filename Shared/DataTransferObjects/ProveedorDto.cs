using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProveedorDto
    {
        public Guid IdProveedor { get; init; }
        public string? NitProveedor {  get; init; }
        public string? Nombre { get; init; }
        public string? Apellido { get; init; }
        public string? Correo { get; init; }
        public long Contacto { get; init; }
        public string? Direccion { get; init; }

    }
}
