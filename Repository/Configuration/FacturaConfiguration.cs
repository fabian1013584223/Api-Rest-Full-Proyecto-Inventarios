//using Entities.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;

//namespace Repository.Configuration
//{
//    public class FacturaConfiguration : IEntityTypeConfiguration<FacturaCliente>
//    {
//        public void Configure(EntityTypeBuilder<FacturaCliente> builder)
//        {
//            builder.HasData(
//                new FacturaCliente
//                {
//                    FacturaVentaId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
//                    Fecha = new DateTime(2023, 1, 1),
                  
//                },
//                new FacturaCliente
//                {
//                    FacturaVentaId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
//                    Fecha = new DateTime(2023, 2, 1),
//                },
//                new FacturaCliente
//                { 
//                    FacturaVentaId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
//                    Fecha = new DateTime(2023, 3, 1),
                   
//                }
//            );
//        }
//    }
//}
