using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace easyharbour.Dados.Migrations
{
    public partial class tabelaAtracacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atracacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Navio = table.Column<string>(nullable: true),
                    Operador = table.Column<string>(nullable: true),
                    Viagem = table.Column<int>(nullable: false),
                    AvisoChegada = table.Column<DateTime>(nullable: false),
                    Autorizacao = table.Column<DateTime>(nullable: true),
                    PrevisaoAtracacao = table.Column<DateTime>(nullable: true),
                    AtracacaoEfetiva = table.Column<DateTime>(nullable: true),
                    Desatracacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atracacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atracacoes");
        }
    }
}
