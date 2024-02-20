using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Repository.Configuration
{
    public class EfectivoConfiguration : IEntityTypeConfiguration<Efectivo>
    {
        public void Configure(EntityTypeBuilder<Efectivo> builder)
        {
            builder.HasData(
                new Efectivo
                {
                    EfectivoId = new Guid("8777E863-AFBA-430D-8DDC-E7AD0D9B1D15"),
                    ValorPago = 342,
                    MetodoPagoId = new Guid("1376D97D-467A-43A7-8705-B707255BF109")
                },
                new Efectivo
                {
                    EfectivoId = new Guid("A40FA99A-0697-4204-A088-4F875A03CF9D"),
                    ValorPago = 342,
                    MetodoPagoId = new Guid("1376D97D-467A-43A7-8705-B707255BF109")
                },
                new Efectivo
                {
                    EfectivoId = new Guid("32C6182C-D349-4A97-9332-80F2240FBE11"),
                    ValorPago = 342,
                    MetodoPagoId = new Guid("1376D97D-467A-43A7-8705-B707255BF109")
                }
            );
        }
    }
}
