using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlAnon.Data.Migrations
{
    public partial class ImagePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImagePosition",
                table: "Inicio",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePosition",
                table: "Inicio");
        }
    }
}
