using Microsoft.EntityFrameworkCore.Migrations;

namespace CMBData.Migrations
{
    public partial class baseV05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Clientes_AnuncianteClienteId",
                table: "Anuncios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_AnuncianteClienteId",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "AnuncianteClienteId",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Clientes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AnuncianteId",
                table: "Anuncios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_AnuncianteId",
                table: "Anuncios",
                column: "AnuncianteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Clientes_AnuncianteId",
                table: "Anuncios",
                column: "AnuncianteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncios_Clientes_AnuncianteId",
                table: "Anuncios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Anuncios_AnuncianteId",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "AnuncianteId",
                table: "Anuncios");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AnuncianteClienteId",
                table: "Anuncios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Anuncios_AnuncianteClienteId",
                table: "Anuncios",
                column: "AnuncianteClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncios_Clientes_AnuncianteClienteId",
                table: "Anuncios",
                column: "AnuncianteClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
