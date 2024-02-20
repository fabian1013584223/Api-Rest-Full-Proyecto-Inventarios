using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasData(
                new Producto
                {
                    ProductoId = new Guid("6BD9DDED-9A5F-412C-9575-2110DBD9B7C6"),
                    Nombre = "Computador Samsung 2018",
                    Cantidad =1,
                    Precio = 2600000,
                    Estado = "Activo",
                    Lugar = "Estante 2",
                    StockId = new Guid("E9208668-35D6-4862-B4F6-2B3FE8F6A525"),
                    IdCategoria = new Guid("4F9A7CDB-C6DD-4C1C-8CA2-88F34C913C54")
                },
                new Producto
                {
                    ProductoId = new Guid("03A78DB6-0E2E-4D18-9001-FBCCB5CC2DCA"),
                    Nombre = "Audifonos inalambricos",
                    Cantidad = 1,
                    Precio = 250000,
                    Estado = "Activo",
                    Lugar = "Estante 1",
                    StockId = new Guid ("F46678CA-5E2E-4B36-8D56-5EB110770BBE"),
                    IdCategoria = new Guid("B130F449-A5F3-4E3E-A165-D73C3B73A241")
                },
                new Producto
                {
                    ProductoId = new Guid("3BBE0BBE-0379-4D32-9FD9-D74A51D319A6"),
                    Nombre = "Mouse inalambrico",
                    Cantidad = 1,
                    Precio = 50000,
                    Estado = "Activo",
                    Lugar = "Estante 3",
                    StockId = new Guid("9FFFC55A-186F-4D62-88B4-78B43B2948C1"),
                    IdCategoria = new Guid("5AF38236-256E-4DED-A81E-8010F08C51B6")
                }
            );
        }
    }
}
