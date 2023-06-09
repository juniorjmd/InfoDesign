using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infoDesign.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lineas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lineas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoConsumos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTipCliente = table.Column<int>(type: "int", nullable: false),
                    idLinea = table.Column<int>(type: "int", nullable: false),
                    Consumo = table.Column<decimal>(type: "decimal(20,10)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(20,10)", nullable: false),
                    Perdida = table.Column<decimal>(type: "decimal(20,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoConsumos", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoricoConsumos_Lineas_idLinea",
                        column: x => x.idLinea,
                        principalTable: "Lineas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoConsumos_Tipo_clientes_idTipCliente",
                        column: x => x.idTipCliente,
                        principalTable: "Tipo_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoConsumos_idLinea",
                table: "HistoricoConsumos",
                column: "idLinea");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoConsumos_idTipCliente",
                table: "HistoricoConsumos",
                column: "idTipCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoConsumos");

            migrationBuilder.DropTable(
                name: "Lineas");

            migrationBuilder.DropTable(
                name: "Tipo_clientes");
        }
    }
}
