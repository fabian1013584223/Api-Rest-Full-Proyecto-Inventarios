using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIRestProyecto.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NitProveedor = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Contacto = table.Column<long>(type: "bigint", maxLength: 60, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CantidadReal = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    CantidadIdeal = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    CantidadMinima = table.Column<int>(type: "int", nullable: false),
                    CantidadAlarma = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NumeroDocumento = table.Column<long>(type: "bigint", maxLength: 60, nullable: false),
                    Contacto = table.Column<long>(type: "bigint", nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "FacturasCompras",
                columns: table => new
                {
                    FacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProveedoresIdProveedor = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasCompras", x => x.FacturaCompraId);
                    table.ForeignKey(
                        name: "FK_FacturasCompras_Proveedores_ProveedoresIdProveedor",
                        column: x => x.ProveedoresIdProveedor,
                        principalTable: "Proveedores",
                        principalColumn: "IdProveedor");
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Cantidad = table.Column<int>(type: "int", maxLength: 60, nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdCategoria = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "StockId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Numerodocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipodocumento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<long>(type: "bigint", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaProveedores",
                columns: table => new
                {
                    DetalleacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    FacturaCompraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaProveedores", x => x.DetalleacturaCompraId);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaProveedores_FacturasCompras_FacturaCompraId",
                        column: x => x.FacturaCompraId,
                        principalTable: "FacturasCompras",
                        principalColumn: "FacturaCompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaProveedores_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricosPrecios",
                columns: table => new
                {
                    IdHistoricoPrecios = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrecioCompra = table.Column<float>(type: "real", maxLength: 60, nullable: false),
                    PrecioVenta = table.Column<float>(type: "real", maxLength: 60, nullable: false),
                    PrecioDescuento = table.Column<float>(type: "real", nullable: false),
                    FechaDescuento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricosPrecios", x => x.IdHistoricoPrecios);
                    table.ForeignKey(
                        name: "FK_HistoricosPrecios_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturasVentas",
                columns: table => new
                {
                    FacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasVentas", x => x.FacturaVentaId);
                    table.ForeignKey(
                        name: "FK_FacturasVentas_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesFacturaVentas",
                columns: table => new
                {
                    DetalleFacturaVentaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValorUnitario = table.Column<float>(type: "real", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    IVA = table.Column<float>(type: "real", nullable: false),
                    ValorDescuento = table.Column<float>(type: "real", nullable: false),
                    ProductoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacturasVentaFacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesFacturaVentas", x => x.DetalleFacturaVentaID);
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_FacturasVentas_FacturasVentaFacturaVentaId",
                        column: x => x.FacturasVentaFacturaVentaId,
                        principalTable: "FacturasVentas",
                        principalColumn: "FacturaVentaId");
                    table.ForeignKey(
                        name: "FK_DetallesFacturaVentas_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPagos",
                columns: table => new
                {
                    IdMetodoPago = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    NombrePlataforma = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FacturaVentaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPagos", x => x.IdMetodoPago);
                    table.ForeignKey(
                        name: "FK_MetodoPagos_FacturasVentas_FacturaVentaId",
                        column: x => x.FacturaVentaId,
                        principalTable: "FacturasVentas",
                        principalColumn: "FacturaVentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "IdCategoria", "Nombre" },
                values: new object[,]
                {
                    { new Guid("4f9a7cdb-c6dd-4c1c-8ca2-88f34c913c54"), "Portatiles" },
                    { new Guid("5af38236-256e-4ded-a81e-8010f08c51b6"), "Implementos" },
                    { new Guid("b130f449-a5f3-4e3e-a165-d73c3b73a241"), "Auriculares" }
                });

            migrationBuilder.InsertData(
                table: "FacturasCompras",
                columns: new[] { "FacturaCompraId", "Fecha", "IdProveedor", "ProveedoresIdProveedor" },
                values: new object[,]
                {
                    { new Guid("025ca3c1-0deb-4afd-ae94-2159a8479811"), new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("75dba8c0-d178-41e7-938c-ed49778fb52a"), new DateTime(2023, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("90abbca8-664d-4b20-b5de-024705497d4a"), new DateTime(2023, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "IdProveedor", "Apellido", "Contacto", "Correo", "Direccion", "NitProveedor", "Nombre" },
                values: new object[,]
                {
                    { new Guid("c9d4c051-49b6-410c-bc78-2d54a9991880"), "Lopez", 31313131L, "lopez@gmail.com", "gaitana", "39487358944", "Maicol Cardona" },
                    { new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"), "Rodriguez", 31313131L, "Rodriguez@gmail.com", "lisboa", "39487358934", "Angel Correa" }
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "StockId", "CantidadAlarma", "CantidadIdeal", "CantidadMinima", "CantidadReal", "FechaIngreso" },
                values: new object[,]
                {
                    { new Guid("9fffc55a-186f-4d62-88b4-78b43b2948c1"), 5, 40, 10, 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(21) },
                    { new Guid("e9208668-35d6-4862-b4f6-2b3fe8f6a525"), 5, 50, 2, 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24) },
                    { new Guid("f46678ca-5e2e-4b36-8d56-5eb110770bbe"), 5, 100, 30, 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(22) }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "IdUsuario", "Apellido", "Contacto", "Contraseña", "Correo", "Direccion", "Nombre", "NumeroDocumento", "Pais" },
                values: new object[,]
                {
                    { new Guid("ddd67d84-a805-489b-a586-eae523327b8f"), "sampeer", 311453339L, "andrisan123", "samper@gmail.com", "Sur", "Santiago Cardona", 3456789033L, "Colombia" },
                    { new Guid("e2bf9020-f6ee-4a9b-a99a-bd3055c5667a"), "Sanitas", 3114567891L, "Soltero123", "Maicol@gmail.com", "Sur", "Maicol Ortiz", 34567890121L, "Colombia" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Cantidad", "Estado", "IdCategoria", "Lugar", "Nombre", "Precio", "StockId" },
                values: new object[,]
                {
                    { new Guid("03a78db6-0e2e-4d18-9001-fbccb5cc2dca"), 1, "Activo", new Guid("b130f449-a5f3-4e3e-a165-d73c3b73a241"), "Estante 1", "Audifonos inalambricos", 250000f, new Guid("f46678ca-5e2e-4b36-8d56-5eb110770bbe") },
                    { new Guid("3bbe0bbe-0379-4d32-9fd9-d74a51d319a6"), 1, "Activo", new Guid("5af38236-256e-4ded-a81e-8010f08c51b6"), "Estante 3", "Mouse inalambrico", 50000f, new Guid("9fffc55a-186f-4d62-88b4-78b43b2948c1") },
                    { new Guid("6bd9dded-9a5f-412c-9575-2110dbd9b7c6"), 1, "Activo", new Guid("4f9a7cdb-c6dd-4c1c-8ca2-88f34c913c54"), "Estante 2", "Computador Samsung 2018", 2600000f, new Guid("e9208668-35d6-4862-b4f6-2b3fe8f6a525") }
                });

            migrationBuilder.InsertData(
                table: "HistoricosPrecios",
                columns: new[] { "IdHistoricoPrecios", "Estado", "FechaDescuento", "PrecioCompra", "PrecioDescuento", "PrecioVenta", "ProductoId" },
                values: new object[,]
                {
                    { new Guid("369ccaf1-e340-4ee9-b612-acc195dc856a"), "Inactivo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), 342f, 234f, 342f, new Guid("6bd9dded-9a5f-412c-9575-2110dbd9b7c6") },
                    { new Guid("8285b178-56af-4939-aada-e35f6e067db5"), "Inactivo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), 678f, 456f, 456f, new Guid("3bbe0bbe-0379-4d32-9fd9-d74a51d319a6") },
                    { new Guid("c20a3432-81eb-48c2-a25e-6574cd445cbb"), "Inactivo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(24), 34f, 45f, 45f, new Guid("03a78db6-0e2e-4d18-9001-fbccb5cc2dca") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioId",
                table: "Cliente",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaProveedores_FacturaCompraId",
                table: "DetallesFacturaProveedores",
                column: "FacturaCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaProveedores_ProductoId",
                table: "DetallesFacturaProveedores",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_FacturasVentaFacturaVentaId",
                table: "DetallesFacturaVentas",
                column: "FacturasVentaFacturaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesFacturaVentas_ProductoId",
                table: "DetallesFacturaVentas",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasCompras_ProveedoresIdProveedor",
                table: "FacturasCompras",
                column: "ProveedoresIdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_FacturasVentas_ClienteId",
                table: "FacturasVentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricosPrecios_ProductoId",
                table: "HistoricosPrecios",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_MetodoPagos_FacturaVentaId",
                table: "MetodoPagos",
                column: "FacturaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_IdCategoria",
                table: "Productos",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_StockId",
                table: "Productos",
                column: "StockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesFacturaProveedores");

            migrationBuilder.DropTable(
                name: "DetallesFacturaVentas");

            migrationBuilder.DropTable(
                name: "HistoricosPrecios");

            migrationBuilder.DropTable(
                name: "MetodoPagos");

            migrationBuilder.DropTable(
                name: "FacturasCompras");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "FacturasVentas");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
