using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Repository.Configuration
{
    public class EntidadBancariaConfiguration : IEntityTypeConfiguration<EntidadBancaria>
    {
        public void Configure(EntityTypeBuilder<EntidadBancaria> builder)
        {
            builder.HasData(
                new EntidadBancaria
                {
                    EntidadBancariaId = new Guid("FD620CB8-34B8-46AF-AE6F-D152576E66E8"),
                    Nombre= "Tarjeta Bancolombia",
                    MetodoPagoId = new Guid("3F2BEC7E-49B4-49D7-8825-7720D818B10C")
                },
                new EntidadBancaria
                {
                    EntidadBancariaId = new Guid("C95A55D0-F879-450A-850B-2BA35F4DB156"),
                    Nombre = "Tarjeta Bancolombia",
                    MetodoPagoId = new Guid("3F2BEC7E-49B4-49D7-8825-7720D818B10C")
                },
                new EntidadBancaria
                {
                    EntidadBancariaId = new Guid("74C78A7C-07FA-4F5E-B3EA-446B0E431D86"),
                    Nombre = "Nequi",
                    MetodoPagoId = new Guid("40E36AB6-44B7-4333-AF08-D622369E5912")
                }
            );
        }
    }
}

