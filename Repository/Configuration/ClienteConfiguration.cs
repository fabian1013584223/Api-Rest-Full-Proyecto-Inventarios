using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Repository.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasData
            (
                new Cliente
                {
                    ClienteId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    Numerodocumento = "1032937888",
                    Tipodocumento = "cedula",
                    Nombre = "Brayan ",
                    Apellido = "cardenas",
                    Correo = "brayan@gmail.com",
                    Contacto = 34563424,
                    UsuarioId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Cliente
                {
                    ClienteId = new Guid("021CA3C1-0DEB-4AFD-AE94-2159A8479811"),
                    Numerodocumento = "1032937444",
                    Tipodocumento = "cedula",
                    Nombre = "dianan ",
                    Apellido = "cardaaaas",
                    Correo = "diana@gmail.com",
                    Contacto = 3456333294,
                    UsuarioId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                 new Cliente
                 {
                     ClienteId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479815"),
                     Numerodocumento = "1032937555",
                     Tipodocumento = "cedula",
                     Nombre = "Brei ",
                     Apellido = "cardenas",
                     Correo = "breu@gmail.com",
                     Contacto = 345637889,
                     UsuarioId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                 }
            );
        }
    }
}
