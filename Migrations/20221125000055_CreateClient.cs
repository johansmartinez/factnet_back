using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace factnetback.Migrations
{
    /// <inheritdoc />
    public partial class CreateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    dni = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nombres = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.dni);
                });

            migrationBuilder.InsertData(
                table: "cliente",
                columns: new[] { "dni", "apellidos", "direccion", "nombres" },
                values: new object[] { "00000", "PRUEBA", "DIRECCIÓN DE PRUEBA", "USUARIO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");
        }
    }
}
