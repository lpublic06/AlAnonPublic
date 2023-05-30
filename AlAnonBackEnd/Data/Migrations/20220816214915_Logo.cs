using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlAnon.Data.Migrations
{
    public partial class Logo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImageFitLogo",
                table: "Inicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageHeightLogo",
                table: "Inicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImagePositionLogo",
                table: "Inicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImageWidthLogo",
                table: "Inicio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImagenDeInicioLogo",
                table: "Inicio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFitLogo",
                table: "Inicio");

            migrationBuilder.DropColumn(
                name: "ImageHeightLogo",
                table: "Inicio");

            migrationBuilder.DropColumn(
                name: "ImagePositionLogo",
                table: "Inicio");

            migrationBuilder.DropColumn(
                name: "ImageWidthLogo",
                table: "Inicio");

            migrationBuilder.DropColumn(
                name: "ImagenDeInicioLogo",
                table: "Inicio");
        }
    }
}
