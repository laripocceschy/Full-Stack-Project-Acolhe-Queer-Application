using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class M02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telefone",
                table: "Usuarios",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "nome_social",
                table: "Usuarios",
                newName: "Nome_social");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "idade",
                table: "Usuarios",
                newName: "Idade");

            migrationBuilder.RenameColumn(
                name: "endereco_numero",
                table: "Usuarios",
                newName: "Endereco_numero");

            migrationBuilder.RenameColumn(
                name: "endereco_logradouro",
                table: "Usuarios",
                newName: "Endereco_logradouro");

            migrationBuilder.RenameColumn(
                name: "endereco_estado",
                table: "Usuarios",
                newName: "Endereco_estado");

            migrationBuilder.RenameColumn(
                name: "endereco_cidade",
                table: "Usuarios",
                newName: "Endereco_cidade");

            migrationBuilder.RenameColumn(
                name: "endereco_cep",
                table: "Usuarios",
                newName: "Endereco_cep");

            migrationBuilder.RenameColumn(
                name: "endereco_bairro",
                table: "Usuarios",
                newName: "Endereco_bairro");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Usuarios",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "bool_admin",
                table: "Usuarios",
                newName: "Bool_admin");

            migrationBuilder.RenameColumn(
                name: "usuario_id",
                table: "Usuarios",
                newName: "Usuario_id");

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Usuarios",
                newName: "telefone");

            migrationBuilder.RenameColumn(
                name: "Nome_social",
                table: "Usuarios",
                newName: "nome_social");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Idade",
                table: "Usuarios",
                newName: "idade");

            migrationBuilder.RenameColumn(
                name: "Endereco_numero",
                table: "Usuarios",
                newName: "endereco_numero");

            migrationBuilder.RenameColumn(
                name: "Endereco_logradouro",
                table: "Usuarios",
                newName: "endereco_logradouro");

            migrationBuilder.RenameColumn(
                name: "Endereco_estado",
                table: "Usuarios",
                newName: "endereco_estado");

            migrationBuilder.RenameColumn(
                name: "Endereco_cidade",
                table: "Usuarios",
                newName: "endereco_cidade");

            migrationBuilder.RenameColumn(
                name: "Endereco_cep",
                table: "Usuarios",
                newName: "endereco_cep");

            migrationBuilder.RenameColumn(
                name: "Endereco_bairro",
                table: "Usuarios",
                newName: "endereco_bairro");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Usuarios",
                newName: "cpf");

            migrationBuilder.RenameColumn(
                name: "Bool_admin",
                table: "Usuarios",
                newName: "bool_admin");

            migrationBuilder.RenameColumn(
                name: "Usuario_id",
                table: "Usuarios",
                newName: "usuario_id");

            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "telefone",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "cpf",
                table: "Usuarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
