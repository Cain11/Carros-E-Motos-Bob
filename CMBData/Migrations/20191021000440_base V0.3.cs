using Microsoft.EntityFrameworkCore.Migrations;

namespace CMBData.Migrations
{
    public partial class baseV03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoCompras_Clientes_ClienteId",
                table: "HistoricoCompras");

            migrationBuilder.DropTable(
                name: "AnunciosAbertos");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoCompras_ClienteId",
                table: "HistoricoCompras");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "HistoricoCompras");

            migrationBuilder.AddColumn<int>(
                name: "AnunciosId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HistoricoComprasId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AnunciosCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncioId = table.Column<int>(nullable: true)
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
                name: "IX_Clientes_HistoricoComprasId",
                table: "Clientes",
                column: "HistoricoComprasId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_HistoricoCompras_HistoricoComprasId",
                table: "Clientes",
                column: "HistoricoComprasId",
                principalTable: "HistoricoCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AnunciosCliente_AnunciosId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_HistoricoCompras_HistoricoComprasId",
                table: "Clientes");

            migrationBuilder.DropTable(
                name: "AnunciosCliente");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_AnunciosId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_HistoricoComprasId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "AnunciosId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "HistoricoComprasId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "HistoricoCompras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AnunciosAbertos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncioId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnunciosAbertos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnunciosAbertos_Anuncios_AnuncioId",
                        column: x => x.AnuncioId,
                        principalTable: "Anuncios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnunciosAbertos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCompras_ClienteId",
                table: "HistoricoCompras",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AnunciosAbertos_AnuncioId",
                table: "AnunciosAbertos",
                column: "AnuncioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnunciosAbertos_ClienteId",
                table: "AnunciosAbertos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoCompras_Clientes_ClienteId",
                table: "HistoricoCompras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
