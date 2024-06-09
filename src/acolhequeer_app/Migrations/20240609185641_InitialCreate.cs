using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Instituicao",
               columns: table => new
               {
                   instituicao_id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   endereco_rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   endereco_bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   endereco_cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   endereco_estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   endereco_numero = table.Column<int>(type: "int", nullable: false),
                   endereco_cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   adm_validacao = table.Column<bool>(type: "bit", nullable: false),
                   pix_doacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   n_vagas = table.Column<int>(type: "int", nullable: false),
                   bool_atd = table.Column<bool>(type: "bit", nullable: false),
                   qtd_disponibilidade = table.Column<int>(type: "int", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Instituicao", x => x.instituicao_id);
               });

            migrationBuilder.AddColumn<string>(
                name: "descricao_casa",
                table: "Instituicao",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Agendamentos",
                columns: table => new
                {
                    Atendimento_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_id = table.Column<int>(type: "int", nullable: false),
                    instituicao_id = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamentos", x => x.Atendimento_id);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Instituicao_instituicao_id",
                        column: x => x.instituicao_id,
                        principalTable: "Instituicao",
                        principalColumn: "instituicao_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agendamentos_Usuarios_Usuario_id",
                        column: x => x.Usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "Usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_instituicao_id",
                table: "Agendamentos",
                column: "instituicao_id");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamentos_Usuario_id",
                table: "Agendamentos",
                column: "Usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "descricao_casa",
                table: "Instituicao");
        }
    }
}
