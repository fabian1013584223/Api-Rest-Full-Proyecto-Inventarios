using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record UsuarioForUpdateDto (
        string Nombre,
        string Direccion,
        string Contraseña,
        string Apellido,
        string Correo,
        long NumeroDocumento,
        long Contacto,
        string Pais,
        IEnumerable<ClienteForCreationDto>? Clientes);

}