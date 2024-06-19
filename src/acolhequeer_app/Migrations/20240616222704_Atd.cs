using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class Atd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Instituicao_instituicao_id",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "instituicao_id",
                table: "Agendamentos",
                newName: "Instituicao_id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_instituicao_id",
                table: "Agendamentos",
                newName: "IX_Agendamentos_Instituicao_id");

            migrationBuilder.AddColumn<bool>(
                name: "IsPsicologico",
                table: "Agendamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsQuarto",
                table: "Agendamentos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Instituicao_Instituicao_id",
                table: "Agendamentos",
                column: "Instituicao_id",
                principalTable: "Instituicao",
                principalColumn: "instituicao_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamentos_Instituicao_Instituicao_id",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "IsPsicologico",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "IsQuarto",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "Instituicao_id",
                table: "Agendamentos",
                newName: "instituicao_id");

            migrationBuilder.RenameIndex(
                name: "IX_Agendamentos_Instituicao_id",
                table: "Agendamentos",
                newName: "IX_Agendamentos_instituicao_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamentos_Instituicao_instituicao_id",
                table: "Agendamentos",
                column: "instituicao_id",
                principalTable: "Instituicao",
                principalColumn: "instituicao_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
