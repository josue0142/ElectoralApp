using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectoralApp.Migrations
{
    public partial class ChangeMaxLenthColumnDescripcionTableCandidatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripción",
                table: "Partidos",
                type: "varchar(75)",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripción",
                table: "Partidos",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(75)",
                oldUnicode: false,
                oldMaxLength: 25);
        }
    }
}
