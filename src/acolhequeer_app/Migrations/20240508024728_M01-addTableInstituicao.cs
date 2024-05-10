using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class M01addTableInstituicao : Migration
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
                    qtd_disponibilidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicao", x => x.instituicao_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instituicao");
        }
    }
}
