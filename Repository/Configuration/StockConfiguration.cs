using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Repository.Configuration
{
    public class StockConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasData
            (
                new Stock
                {
                    StockId = new Guid("E9208668-35D6-4862-B4F6-2B3FE8F6A525"),
                    CantidadReal = 150,
                    CantidadIdeal = 50,
                    CantidadMinima = 2,
                    CantidadAlarma = 5,
                    FechaIngreso = new DateTime (2023/06/14)            
                },
                new Stock
                {
                    StockId = new Guid("F46678CA-5E2E-4B36-8D56-5EB110770BBE"),
                    CantidadReal = 250,
                    CantidadIdeal = 100,
                    CantidadMinima = 30,
                    CantidadAlarma = 5,
                    FechaIngreso = new DateTime (2023/06/15)
                },
                new Stock
                {
                    StockId = new Guid("9FFFC55A-186F-4D62-88B4-78B43B2948C1"),
                    CantidadReal = 80,
                    CantidadIdeal = 40,
                    CantidadMinima = 10,
                    CantidadAlarma = 5,
                    FechaIngreso = new DateTime (2023/06/16)
                }
            );
        }
    }
}
