using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace factnet_back.Migrations
{
    public partial class changeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS",
                column: "proveedorId",
                principalTable: "PROVEEDORES",
                principalColumn: "proveedorId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS",
                column: "proveedorId",
                principalTable: "PROVEEDORES",
                principalColumn: "proveedorId");
        }
    }
}
