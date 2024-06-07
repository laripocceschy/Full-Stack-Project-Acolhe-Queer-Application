using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer.Migrations
{
    /// <inheritdoc />
    public partial class M03AddTableReservaQuarto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReservaQuartos",
                columns: table => new
                {
                    Reserva_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instituicao_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Check_in = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Check_out = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_reserva = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaQuartos", x => x.Reserva_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaQuartos");
        }
    }
}
