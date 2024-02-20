using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ProveedorForUpdateDto (
        string NitProveedor,
        string Nombre,
        string Apellido,
        string Correo,
        long Contacto,
        string Direccion,
        IEnumerable<ClienteForCreationDto>? FacturaProvedor);
        

}
