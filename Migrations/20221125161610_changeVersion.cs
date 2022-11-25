using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace factnet_back.Migrations
{
    public partial class changeVersion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    fechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.dni);
                });

            migrationBuilder.CreateTable(
                name: "PROVEEDORES",
                columns: table => new
                {
                    proveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDORES", x => x.proveedorId);
                });

            migrationBuilder.CreateTable(
                name: "FACTURAS",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    facturacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteDni = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FACTURAS", x => x.id);
                    table.ForeignKey(
                        name: "FK_FACTURAS_CLIENTES_clienteDni",
                        column: x => x.clienteDni,
                        principalTable: "CLIENTES",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTOS",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    precioUnitario = table.Column<int>(type: "int", nullable: false),
                    proveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTOS", x => x.id);
                    table.ForeignKey(
                        name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                        column: x => x.proveedorId,
                        principalTable: "PROVEEDORES",
                        principalColumn: "proveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VENTAS",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    facturaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    unidades = table.Column<int>(type: "int", nullable: false),
                    productoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VENTAS", x => x.id);
                    table.ForeignKey(
                        name: "FK_VENTAS_FACTURAS_facturaId",
                        column: x => x.facturaId,
                        principalTable: "FACTURAS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VENTAS_PRODUCTOS_productoId",
                        column: x => x.productoId,
                        principalTable: "PRODUCTOS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CLIENTES",
                columns: new[] { "dni", "apellidos", "direccion", "fechaNacimiento", "nombres" },
                values: new object[] { "00000", "PRUEBA", "DIRECCIÓN DE PRUEBA", new DateTime(2000, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "USUARIO" });

            migrationBuilder.InsertData(
                table: "PROVEEDORES",
                columns: new[] { "proveedorId", "nombre" },
                values: new object[] { new Guid("40b4111a-defd-4539-942c-0adc8225e413"), "PROVEEDOR DE PRUEBA" });

            migrationBuilder.InsertData(
                table: "FACTURAS",
                columns: new[] { "id", "clienteDni", "facturacion" },
                values: new object[] { new Guid("62881386-8eee-4ca2-b946-5abc0d8c73e7"), "00000", new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "PRODUCTOS",
                columns: new[] { "id", "nombre", "precioUnitario", "proveedorId" },
                values: new object[] { new Guid("96b4bd45-9c9e-4e1f-85ee-9c5ea0e5c715"), "PRODUCTO DE PRUEBA", 1200, new Guid("40b4111a-defd-4539-942c-0adc8225e413") });

            migrationBuilder.InsertData(
                table: "VENTAS",
                columns: new[] { "id", "facturaId", "productoId", "unidades" },
                values: new object[] { new Guid("09d15e2c-e1cc-4d55-ac4b-5f01c098b899"), new Guid("62881386-8eee-4ca2-b946-5abc0d8c73e7"), new Guid("96b4bd45-9c9e-4e1f-85ee-9c5ea0e5c715"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_FACTURAS_clienteDni",
                table: "FACTURAS",
                column: "clienteDni");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTOS_proveedorId",
                table: "PRODUCTOS",
                column: "proveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_facturaId",
                table: "VENTAS",
                column: "facturaId");

            migrationBuilder.CreateIndex(
                name: "IX_VENTAS_productoId",
                table: "VENTAS",
                column: "productoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VENTAS");

            migrationBuilder.DropTable(
                name: "FACTURAS");

            migrationBuilder.DropTable(
                name: "PRODUCTOS");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "PROVEEDORES");
        }
    }
}
