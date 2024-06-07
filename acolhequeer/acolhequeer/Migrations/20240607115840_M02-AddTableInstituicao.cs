using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer.Migrations
{
    /// <inheritdoc />
    public partial class M02AddTableInstituicao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    Instituicao_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco_numero = table.Column<int>(type: "int", nullable: false),
                    Endereco_cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adm_validacao = table.Column<bool>(type: "bit", nullable: false),
                    Pix_doacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    N_vagas = table.Column<int>(type: "int", nullable: false),
                    Bool_atd = table.Column<bool>(type: "bit", nullable: false),
                    Qtd_disponibilidade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.Instituicao_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instituicoes");
        }
    }
}
