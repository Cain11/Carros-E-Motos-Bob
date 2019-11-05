using Microsoft.EntityFrameworkCore.Migrations;

namespace CMBData.Migrations
{
    public partial class baseV04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AnunciosCliente_AnunciosId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "AnunciosCliente");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_AnunciosId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "AnunciosId",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnunciosId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnunciosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnunciosCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnunciosCliente_Anuncios_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_AnunciosId",
                table: "Clientes",
                column: "AnunciosId");

            migrationBuilder.CreateIndex(
                name: "IX_AnunciosCliente_AnuncioId",
                table: "AnunciosCliente",
                column: "AnuncioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AnunciosCliente_AnunciosId",
                table: "Clientes",
                column: "AnunciosId",
                principalTable: "AnunciosCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
