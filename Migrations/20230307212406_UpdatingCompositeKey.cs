using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Name",
                schema: "RssReader",
                table: "CategoryItem");

            migrationBuilder.AddPrimaryKey(
                name: "Name",
                schema: "RssReader",
                table: "CategoryItem",
                columns: new[] { "CategoryName", "ItemForeignKey" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "Name",
                schema: "RssReader",
                table: "CategoryItem");

            migrationBuilder.AddPrimaryKey(
                name: "Name",
                schema: "RssReader",
                table: "CategoryItem",
                column: "CategoryName");
        }
    }
}
