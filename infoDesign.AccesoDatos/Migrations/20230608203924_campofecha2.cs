using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infoDesign.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class campofecha2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Consumo",
                table: "HistoricoConsumos",
                type: "decimal(20,10)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "HistoricoConsumos",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
