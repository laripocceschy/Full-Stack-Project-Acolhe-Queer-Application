using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer.Migrations
{
    /// <inheritdoc />
    public partial class M01AddTableUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
