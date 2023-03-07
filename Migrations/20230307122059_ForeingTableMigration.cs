using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ForeingTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryItemKey",
                schema: "RssReader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemKey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryItemKey_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "RssReader",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItemKey_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "RssReader",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemKey_CategoryId",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemKey_ItemId",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItemKey",
                schema: "RssReader");
        }
    }
}
