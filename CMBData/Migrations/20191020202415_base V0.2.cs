using Microsoft.EntityFrameworkCore.Migrations;

namespace CMBData.Migrations
{
    public partial class baseV02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroDepesquisas",
                table: "Modelos",
                newName: "NumeroDePesquisas");

            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroDePesquisas",
                table: "Modelos",
                newName: "NumeroDepesquisas");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
