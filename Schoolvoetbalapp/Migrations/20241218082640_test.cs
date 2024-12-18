using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Schoolvoetbalapp.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wedstrijden_Gokkers_GokkerId",
                table: "Wedstrijden");

            migrationBuilder.DropIndex(
                name: "IX_Wedstrijden_GokkerId",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "GokkerId",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "Wedbedrag",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Gokkers");

            migrationBuilder.RenameColumn(
                name: "Teams",
                table: "Wedstrijden",
                newName: "UitTeam");

            migrationBuilder.RenameColumn(
                name: "Gebruikersnaam",
                table: "Gokkers",
                newName: "Naam");

            migrationBuilder.AlterColumn<string>(
                name: "Datum",
                table: "Wedstrijden",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ThuisTeam",
                table: "Wedstrijden",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<double>(
                name: "Budget",
                table: "Gokkers",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThuisTeam",
                table: "Wedstrijden");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Gokkers");

            migrationBuilder.RenameColumn(
                name: "UitTeam",
                table: "Wedstrijden",
                newName: "Teams");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "Gokkers",
                newName: "Gebruikersnaam");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Datum",
                table: "Wedstrijden",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "GokkerId",
                table: "Wedstrijden",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Wedbedrag",
                table: "Wedstrijden",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Gokkers",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Wedstrijden_GokkerId",
                table: "Wedstrijden",
                column: "GokkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wedstrijden_Gokkers_GokkerId",
                table: "Wedstrijden",
                column: "GokkerId",
                principalTable: "Gokkers",
                principalColumn: "Id");
        }
    }
}
