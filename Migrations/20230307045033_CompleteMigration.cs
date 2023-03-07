using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class CompleteMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                schema: "RssReader",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "RssReader",
                newName: "Category",
                newSchema: "RssReader");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_CategoryId",
                schema: "RssReader",
                table: "Category",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_CategoryId",
                schema: "RssReader",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                schema: "RssReader",
                newName: "Categories",
                newSchema: "RssReader");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                schema: "RssReader",
                table: "Categories",
                column: "Id");
        }
    }
}
