﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoriesReadingAPI.Migrations
{
    /// <inheritdoc />
    public partial class LanguagesIsShownMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShown",
                table: "Languages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShown",
                table: "Languages");
        }
    }
}
