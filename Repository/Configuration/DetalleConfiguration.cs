//using Entities.Models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;

//namespace Repository.Configuration
//{
//    public class DetalleFacturaClienteConfiguration : IEntityTypeConfiguration<DetalleFacturaCliente>
//    {
//        public void Configure(EntityTypeBuilder<DetalleFacturaCliente> builder)
//        {
//            builder.HasData(
//                new DetalleFacturaCliente
//                {
//                    DetalleFacturaVentaID = new Guid("a1b2c3d4-e5f6-4a5b-b6c7-d8e9f0a1b2c3"),
//                    Cantidad = 40,
//                    ValorUnitario = 10000,
//                    ValorDescuento = 10,
//                },
//                new DetalleFacturaCliente
//                {
//                    DetalleFacturaVentaID = new Guid("b2c3d4e5-f6g7-4b5c-b6d7-e8f9g0b2c3d4"),
//                    Cantidad = 90,
//                    ValorUnitario = 98000,
//                    ValorDescuento = 10,
//                },
//                new DetalleFacturaCliente
//                {
//                    DetalleFacturaVentaID = new Guid("c3d4e5f6-g7h8-4c5b-b6d7-e9f0g1c3d4e5"),
//                    Cantidad = 80,
//                    ValorUnitario = 20000,
//                    ValorDescuento = 10,
//                }
//            );
//        }
//    }
//}
