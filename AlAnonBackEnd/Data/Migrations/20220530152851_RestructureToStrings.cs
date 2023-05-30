using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlAnon.Data.Migrations
{
    public partial class RestructureToStrings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupos_TypoDeJunta_IdTypo",
                table: "Grupos");

            migrationBuilder.DropTable(
                name: "DiasGrupo");

            migrationBuilder.DropTable(
                name: "TypoDeJunta");

            migrationBuilder.DropTable(
                name: "Dias");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_IdTypo",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "IdTypo",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "Presencial",
                table: "Grupos");

            migrationBuilder.AlterColumn<string>(
                name: "Alateen",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "Dias",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeJunta",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dias",
                table: "Grupos");

            migrationBuilder.DropColumn(
                name: "TipoDeJunta",
                table: "Grupos");

            migrationBuilder.AlterColumn<bool>(
                name: "Alateen",
                table: "Grupos",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "IdTypo",
                table: "Grupos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Presencial",
                table: "Grupos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Dias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dias", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "DiasGrupo",
                columns: table => new
                {
                    DiasId = table.Column<int>(type: "int", nullable: false),
                    GruposId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasGrupo", x => new { x.DiasId, x.GruposId });
                    table.ForeignKey(
                        name: "FK_DiasGrupo_Dias_DiasId",
                        column: x => x.DiasId,
                        principalTable: "Dias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiasGrupo_Grupos_GruposId",
                        column: x => x.GruposId,
                        principalTable: "Grupos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_IdTypo",
                table: "Grupos",
                column: "IdTypo");

            migrationBuilder.CreateIndex(
                name: "IX_DiasGrupo_GruposId",
                table: "DiasGrupo",
                column: "GruposId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupos_TypoDeJunta_IdTypo",
                table: "Grupos",
                column: "IdTypo",
                principalTable: "TypoDeJunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
