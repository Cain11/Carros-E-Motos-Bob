using Microsoft.EntityFrameworkCore.Migrations;

namespace CMBData.Migrations
{
    public partial class basev06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_HistoricoCompras_HistoricoComprasId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "HistoricoCompras");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_HistoricoComprasId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "HistoricoComprasId",
                table: "Clientes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoricoComprasId",
                table: "Clientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistoricoCompras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompraId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoCompras_Anuncios_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_HistoricoComprasId",
                table: "Clientes",
                column: "HistoricoComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCompras_CompraId",
                table: "HistoricoCompras",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_HistoricoCompras_HistoricoComprasId",
                table: "Clientes",
                column: "HistoricoComprasId",
                principalTable: "HistoricoCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
