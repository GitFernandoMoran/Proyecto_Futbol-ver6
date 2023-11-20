using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseDatos.Server.Migrations
{
    /// <inheritdoc />
    public partial class Creacion_Confederacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confederacion",
                table: "Ligas");

            migrationBuilder.AddColumn<int>(
                name: "ConfederacionId",
                table: "Ligas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Confederaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_confederacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confederaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_equipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_jugador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Partidos_jugados = table.Column<int>(type: "int", nullable: false),
                    Goles = table.Column<int>(type: "int", nullable: false),
                    Asistencias = table.Column<int>(type: "int", nullable: false),
                    Tarjetas_amarillas = table.Column<int>(type: "int", nullable: false),
                    Tarjetas_rojas = table.Column<int>(type: "int", nullable: false),
                    Fotografia = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ligas_ConfederacionId",
                table: "Ligas",
                column: "ConfederacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ligas_Confederaciones_ConfederacionId",
                table: "Ligas",
                column: "ConfederacionId",
                principalTable: "Confederaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ligas_Confederaciones_ConfederacionId",
                table: "Ligas");

            migrationBuilder.DropTable(
                name: "Confederaciones");

            migrationBuilder.DropTable(
                name: "Equipos");

            migrationBuilder.DropTable(
                name: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Ligas_ConfederacionId",
                table: "Ligas");

            migrationBuilder.DropColumn(
                name: "ConfederacionId",
                table: "Ligas");

            migrationBuilder.AddColumn<string>(
                name: "Confederacion",
                table: "Ligas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
