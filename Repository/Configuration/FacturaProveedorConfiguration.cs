using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class FacturaProveedorConfiguration : IEntityTypeConfiguration<FacturaProveedor>
{
	public void Configure(EntityTypeBuilder<FacturaProveedor> builder)
	{
		builder.HasData
		(
			new FacturaProveedor
            {
				FacturaCompraId = new Guid("90abbca8-664d-4b20-b5de-024705497d4a"),
                Fecha = new DateTime(2023, 9, 17),
            },
			new FacturaProveedor
            {
                FacturaCompraId = new Guid("75dba8c0-d178-41e7-938c-ed49778fb52a"),
                Fecha = new DateTime(2023, 5, 21),
            },
			 new FacturaProveedor
             {
                 FacturaCompraId = new Guid("025ca3c1-0deb-4afd-ae94-2159a8479811"),
                 Fecha = new DateTime(2023, 7, 10),
             }
		);
	}
}
