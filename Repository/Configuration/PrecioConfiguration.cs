using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Repository.Configuration
{
    public class PrecioConfiguration : IEntityTypeConfiguration<Precios>
    {
        public void Configure(EntityTypeBuilder<Precios> builder)
        {
            builder.HasData(
                new Precios
                {
                    IdHistoricoPrecios = new Guid("369CCAF1-E340-4EE9-B612-ACC195DC856A"),
                    PrecioCompra = 342,
                    PrecioVenta = 342,
                    PrecioDescuento = 234,
                    FechaDescuento = new DateTime(2023 / 06 / 14),
                    Estado = "Inactivo",
                    ProductoId = new Guid("6BD9DDED-9A5F-412C-9575-2110DBD9B7C6")

                },
                new Precios
                {
                    IdHistoricoPrecios = new Guid("C20A3432-81EB-48C2-A25E-6574CD445CBB"),
                    PrecioCompra = 34,
                    PrecioVenta = 45,
                    PrecioDescuento = 45,
                    FechaDescuento = new DateTime(2023 / 06 / 14),
                    Estado = "Inactivo",
                    ProductoId = new Guid("03A78DB6-0E2E-4D18-9001-FBCCB5CC2DCA")
                },
                new Precios
                {
                    IdHistoricoPrecios = new Guid("8285B178-56AF-4939-AADA-E35F6E067DB5"),
                    PrecioCompra = 678,
                    PrecioVenta = 456,
                    PrecioDescuento = 456,
                    FechaDescuento = new DateTime(2023 / 06 / 14),
                    Estado = "Inactivo",
                    ProductoId = new Guid("3BBE0BBE-0379-4D32-9FD9-D74A51D319A6")
                }
            );
        }
    }
}
