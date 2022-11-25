using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace factnetback.Migrations
{
    /// <inheritdoc />
    public partial class AddProveedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "CLIENTES");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CLIENTES",
                table: "CLIENTES",
                column: "dni");

            migrationBuilder.CreateTable(
                name: "PROVEEDORES",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROVEEDORES", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "PROVEEDORES",
                columns: new[] { "id", "nombre" },
                values: new object[] { new Guid("40b4111a-defd-4539-942c-0adc8225e413"), "PROVEEDOR DE PRUEBA" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PROVEEDORES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CLIENTES",
                table: "CLIENTES");

            migrationBuilder.RenameTable(
                name: "CLIENTES",
                newName: "cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "dni");
        }
    }
}
