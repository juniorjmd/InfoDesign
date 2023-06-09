using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infoDesign.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class campofecha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha",
                table: "HistoricoConsumos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Consumo",
                table: "HistoricoConsumos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Consumo",
                table: "HistoricoConsumos",
                type: "decimal(20,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "fecha",
                table: "HistoricoConsumos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
