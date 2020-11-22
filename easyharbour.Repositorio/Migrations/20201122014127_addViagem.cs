using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace easyharbour.Dados.Migrations
{
    public partial class addViagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Beam",
                table: "Navios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Draft",
                table: "Navios",
                nullable: false,
                defaultValue: 0.0);
                       
            migrationBuilder.CreateTable(
                name: "Viagens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    NavioId = table.Column<Guid>(nullable: false),
                    BercoGraoId = table.Column<Guid>(nullable: false),
                    TipoProduto = table.Column<int>(nullable: false),
                    Origem = table.Column<string>(nullable: true),
                    Destuno = table.Column<string>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viagens_BercosGraos_BercoGraoId",
                        column: x => x.BercoGraoId,
                        principalTable: "BercosGraos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Viagens_Navios_NavioId",
                        column: x => x.NavioId,
                        principalTable: "Navios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_BercoGraoId",
                table: "Viagens",
                column: "BercoGraoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_NavioId",
                table: "Viagens",
                column: "NavioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
  
            migrationBuilder.DropTable(
                name: "Viagens");

            migrationBuilder.DropColumn(
                name: "Beam",
                table: "Navios");

            migrationBuilder.DropColumn(
                name: "Draft",
                table: "Navios");
        }
    }
}
