using System;
using System.Collections.Generic;

namespace Shared.DataTransferObjects
{
    public record UsuarioForCreationDto(
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

