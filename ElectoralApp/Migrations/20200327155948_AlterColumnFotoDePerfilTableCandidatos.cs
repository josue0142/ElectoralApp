using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectoralApp.Migrations
{
    public partial class AlterColumnFotoDePerfilTableCandidatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Foto_de_perfil",
                table: "Candidatos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.AlterColumn<string>(
                name: "Foto_de_perfil",
                table: "Candidatos",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
