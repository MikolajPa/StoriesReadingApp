using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoriesReadingAPI.Migrations
{
    /// <inheritdoc />
    public partial class LanguageLevelsAndTexts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Languages");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LanguageLevels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Power",
                table: "LanguageLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TextTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageOriginalId = table.Column<int>(type: "int", nullable: false),
                    LanguageTranslationId = table.Column<int>(type: "int", nullable: false),
                    LanguageLevelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Texts_LanguageLevels_LanguageLevelsId",
                        column: x => x.LanguageLevelsId,
                        principalTable: "LanguageLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Texts_Languages_LanguageOriginalId",
                        column: x => x.LanguageOriginalId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Texts_Languages_LanguageTranslationId",
                        column: x => x.LanguageTranslationId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Texts_LanguageLevelsId",
                table: "Texts",
                column: "LanguageLevelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Texts_LanguageOriginalId",
                table: "Texts",
                column: "LanguageOriginalId");

            migrationBuilder.CreateIndex(
                name: "IX_Texts_LanguageTranslationId",
                table: "Texts",
                column: "LanguageTranslationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LanguageLevels");

            migrationBuilder.DropColumn(
                name: "Power",
                table: "LanguageLevels");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
