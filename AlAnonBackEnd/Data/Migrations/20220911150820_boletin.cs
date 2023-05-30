using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlAnon.Data.Migrations
{
    public partial class boletin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boletin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pagina1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pagina2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaDeBoletin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EsValida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletin", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletin");
        }
    }
}
