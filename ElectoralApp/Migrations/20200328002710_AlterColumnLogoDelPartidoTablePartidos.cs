using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectoralApp.Migrations
{
    public partial class AlterColumnLogoDelPartidoTablePartidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Logo_del_partido",
                table: "Partidos",
                unicode: false,
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Logo_del_partido",
                table: "Partidos",
                unicode: false,
                maxLength: 400,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}
