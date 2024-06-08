using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateReservaQuartoForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Usuario_id",
                table: "ReservaQuartos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Instituicao_id",
                table: "ReservaQuartos",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AtendimentosPsicologico",
                columns: table => new
                {
                    Atendimento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_id = table.Column<int>(type: "int", nullable: false),
                    Instituicao_id = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentosPsicologico", x => x.Atendimento_id);
                    table.ForeignKey(
                        name: "FK_AtendimentosPsicologico_Instituicoes_Instituicao_id",
                        column: x => x.Instituicao_id,
                        principalTable: "Instituicoes",
                        principalColumn: "Instituicao_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtendimentosPsicologico_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservaQuartos_Instituicao_id",
                table: "ReservaQuartos",
                column: "Instituicao_id");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaQuartos_Usuario_id",
                table: "ReservaQuartos",
                column: "Usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosPsicologico_Instituicao_id",
                table: "AtendimentosPsicologico",
                column: "Instituicao_id");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentosPsicologico_Usuario_id",
                table: "AtendimentosPsicologico",
                column: "Usuario_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaQuartos_Instituicoes_Instituicao_id",
                table: "ReservaQuartos",
                column: "Instituicao_id",
                principalTable: "Instituicoes",
                principalColumn: "Instituicao_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservaQuartos_Usuarios_Usuario_id",
                table: "ReservaQuartos",
                column: "Usuario_id",
                principalTable: "Usuarios",
                principalColumn: "Usuario_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservaQuartos_Instituicoes_Instituicao_id",
                table: "ReservaQuartos");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservaQuartos_Usuarios_Usuario_id",
                table: "ReservaQuartos");

            migrationBuilder.DropTable(
                name: "AtendimentosPsicologico");

            migrationBuilder.DropIndex(
                name: "IX_ReservaQuartos_Instituicao_id",
                table: "ReservaQuartos");

            migrationBuilder.DropIndex(
                name: "IX_ReservaQuartos_Usuario_id",
                table: "ReservaQuartos");

            migrationBuilder.AlterColumn<string>(
                name: "Usuario_id",
                table: "ReservaQuartos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Instituicao_id",
                table: "ReservaQuartos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
