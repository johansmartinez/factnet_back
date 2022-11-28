using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace factnet_back.Migrations
{
    public partial class cascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS");

            migrationBuilder.AlterColumn<Guid>(
                name: "proveedorId",
                table: "PRODUCTOS",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS",
                column: "proveedorId",
                principalTable: "PROVEEDORES",
                principalColumn: "proveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS");

            migrationBuilder.AlterColumn<Guid>(
                name: "proveedorId",
                table: "PRODUCTOS",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUCTOS_PROVEEDORES_proveedorId",
                table: "PRODUCTOS",
                column: "proveedorId",
                principalTable: "PROVEEDORES",
                principalColumn: "proveedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
