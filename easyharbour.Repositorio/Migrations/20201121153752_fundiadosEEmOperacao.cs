using Microsoft.EntityFrameworkCore.Migrations;

namespace easyharbour.Dados.Migrations
{
    public partial class fundiadosEEmOperacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmOperacao",
                table: "Atracacoes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Fundiado",
                table: "Atracacoes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmOperacao",
                table: "Atracacoes");

            migrationBuilder.DropColumn(
                name: "Fundiado",
                table: "Atracacoes");
        }
    }
}
