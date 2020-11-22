using Microsoft.EntityFrameworkCore.Migrations;

namespace easyharbour.Dados.Migrations
{
    public partial class addUltimasAlteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Destuno",
                table: "Viagens",
                newName: "Destino");

            migrationBuilder.AddColumn<double>(
                name: "Largura",
                table: "Navios",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Viagem",
                table: "Atracacoes",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Largura",
                table: "Navios");

            migrationBuilder.RenameColumn(
                name: "Destino",
                table: "Viagens",
                newName: "Destuno");

            migrationBuilder.AlterColumn<int>(
                name: "Viagem",
                table: "Atracacoes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
