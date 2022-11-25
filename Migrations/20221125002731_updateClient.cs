using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace factnetback.Migrations
{
    /// <inheritdoc />
    public partial class updateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaNacimiento",
                table: "cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "cliente",
                keyColumn: "dni",
                keyValue: "00000",
                column: "fechaNacimiento",
                value: new DateTime(2000, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaNacimiento",
                table: "cliente");
        }
    }
}
