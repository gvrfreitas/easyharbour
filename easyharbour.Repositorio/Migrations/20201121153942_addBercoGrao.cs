using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace easyharbour.Dados.Migrations
{
    public partial class addBercoGrao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BercosGraos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Comprimento = table.Column<double>(nullable: false),
                    CalaodBaixa = table.Column<double>(nullable: false),
                    CalaodAlta = table.Column<double>(nullable: false),
                    CaladoMaximoTrecho = table.Column<string>(nullable: true),
                    Prancha = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BercosGraos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BercosGraos");
        }
    }
}
