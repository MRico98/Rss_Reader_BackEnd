using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCategoryModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItemKey",
                schema: "RssReader");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "RssReader");

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                schema: "RssReader",
                columns: table => new
                {
                    CategoryName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Name", x => x.CategoryName);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Item_ItemForeignKey",
                        column: x => x.ItemForeignKey,
                        principalSchema: "RssReader",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_ItemForeignKey",
                schema: "RssReader",
                table: "CategoryItem",
                column: "ItemForeignKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItem",
                schema: "RssReader");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "RssReader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CategoryId", x => x.Id);
                    table.UniqueConstraint("AK_Category_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItemKey",
                schema: "RssReader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryForeignKey = table.Column<int>(type: "int", nullable: false),
                    ItemForeignKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CategoryItemId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryItemKey_Category_CategoryForeignKey",
                        column: x => x.CategoryForeignKey,
                        principalSchema: "RssReader",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItemKey_Item_CategoryForeignKey",
                        column: x => x.CategoryForeignKey,
                        principalSchema: "RssReader",
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemKey_CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "CategoryForeignKey");
        }
    }
}
