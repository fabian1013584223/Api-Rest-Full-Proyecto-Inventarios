using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasData
            (
                new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = "Maicol Ortiz",
                    Direccion = "Sur",
                    Contraseña = "Soltero123",
                    Apellido = "Sanitas",
                    Correo = "Maicol@gmail.com",
                    NumeroDocumento = 34567890121,
                    Contacto = 3114567891,
                    Pais = "Colombia",
                },
                new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nombre = "Santiago Cardona",
                    Direccion = "Sur",
                    Contraseña = "andrisan123",
                    Apellido = "sampeer",
                    Correo = "samper@gmail.com",
                    NumeroDocumento = 3456789033,
                    Contacto = 311453339,
                    Pais = "Colombia",
                }
            );
        }
    }
}
