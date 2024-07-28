using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoriesReadingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPowersToSentences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Sentences",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Sentences");
        }
    }
}
