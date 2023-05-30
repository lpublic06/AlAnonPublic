using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlAnon.Data.Migrations
{
    public partial class WellDefinedKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTypo",
                table: "Grupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypoDeJunta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypoDeJunta", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_IdTypo",
                table: "Grupos",
                column: "IdTypo");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_TypoDeJunta_IdTypo",
                table: "Grupos",
                column: "IdTypo",
                principalTable: "TypoDeJunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_TypoDeJunta_IdTypo",
                table: "Grupos");

            migrationBuilder.DropTable(
                name: "TypoDeJunta");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_IdTypo",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "IdTypo",
                table: "Grupos");
        }
    }
}
