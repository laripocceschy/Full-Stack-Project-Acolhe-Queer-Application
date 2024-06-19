using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
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
                    descricao_casa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bool_atd = table.Column<bool>(type: "bit", nullable: false),
                    qtd_disponibilidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.instituicao_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco_numero = table.Column<int>(type: "int", nullable: true),
                    Endereco_cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bool_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placa = table.Column<int>(type: "int", nullable: false),
                    AnoFabricacao = table.Column<int>(type: "int", nullable: false),
                    AnoModelo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Instituicao");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
