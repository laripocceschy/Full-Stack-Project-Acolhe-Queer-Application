using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer.Migrations
{
    /// <inheritdoc />
    /// <inheritdoc />
    public partial class M04AddTableAtendimentosPsicologico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtendimentosPsicologico",
                columns: table => new
                {
                    Atendimento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_id = table.Column<int>(nullable: false),
                    Instituicao_id = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosPsicologico", x => x.Atendimento_id);
                    table.ForeignKey(
                        name: "FK_AtendimentosPsicologico_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentosPsicologico_Instituicoes_Instituicao_id",
                        column: x => x.Instituicao_id,
                        principalTable: "Instituicoes",
                        principalColumn: "Instituicao_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosPsicologico_Usuario_id",
                table: "AtendimentosPsicologico",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosPsicologico_Instituicao_id",
                table: "AtendimentosPsicologico",
                column: "Instituicao_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentosPsicologico");
        }
    }
}
