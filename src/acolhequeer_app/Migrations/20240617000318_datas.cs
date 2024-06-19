using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace acolhequeer_app.Migrations
{
    /// <inheritdoc />
    public partial class datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Agendamentos",
                newName: "Data_psi");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_in",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_out",
                table: "Agendamentos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_in",
                table: "Agendamentos");

            migrationBuilder.DropColumn(
                name: "Data_out",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "Data_psi",
                table: "Agendamentos",
                newName: "Data");
        }
    }
}
