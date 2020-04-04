using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectoralApp.Migrations
{
    public partial class AlterColumnFechaDeRealizacionTableElecciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_de_realización",
                table: "Elecciones",
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
                name: "Fecha_de_realización",
                table: "Elecciones",
                unicode: false,
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldUnicode: false,
                oldMaxLength: 25);
        }
    }
}
