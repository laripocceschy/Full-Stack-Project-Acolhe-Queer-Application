using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class M2AddTableUsuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idade = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<int>(type: "int", nullable: false),
                    telefone = table.Column<int>(type: "int", nullable: false),
                    endereco_rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endereco_bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endereco_cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endereco_estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    endereco_numero = table.Column<int>(type: "int", nullable: false),
                    endereco_cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bool_admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
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
