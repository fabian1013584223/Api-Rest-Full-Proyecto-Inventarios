using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Repository.Configuration
{

    public class ProveedorConfiguration : IEntityTypeConfiguration<Proveedor>
    {
        public void Configure(EntityTypeBuilder<Proveedor> builder)
        {
            builder.HasData
            (
                new Proveedor
                {
                    IdProveedor = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    NitProveedor= "39487358934", 
                    Nombre = "Angel Correa",
                    Apellido = "Rodriguez",
                    Correo = "Rodriguez@gmail.com",
                    Contacto = 31313131,
                    Direccion = "lisboa"
                },
                new Proveedor
                {
                    IdProveedor = new Guid("c9d4c051-49b6-410c-bc78-2d54a9991880"),
                    NitProveedor = "39487358944",
                    Nombre = "Maicol Cardona",
                    Apellido = "Lopez",
                    Correo = "lopez@gmail.com",
                    Contacto = 31313131,
                    Direccion = "gaitana"
                }
            );
        }
    }

}
