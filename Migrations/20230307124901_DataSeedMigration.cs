using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemKey_Category_CategoryId",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemKey_Item_ItemId",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryItemKey",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.DropIndex(
                name: "IX_CategoryItemKey_ItemId",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                schema: "RssReader",
                table: "CategoryItemKey",
                newName: "ItemForeignKey");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                schema: "RssReader",
                table: "CategoryItemKey",
                newName: "CategoryForeignKey");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItemKey_CategoryId",
                schema: "RssReader",
                table: "CategoryItemKey",
                newName: "IX_CategoryItemKey_CategoryForeignKey");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                schema: "RssReader",
                table: "Item",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_CategoryItemId",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "Id");

            migrationBuilder.InsertData(
                schema: "RssReader",
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "CategoryNombre" });

            migrationBuilder.InsertData(
                schema: "RssReader",
                table: "Item",
                columns: new[] { "Id", "CreationDate", "Description", "Title", "Url" },
                values: new object[] { 1, new DateTime(2023, 3, 7, 6, 49, 1, 503, DateTimeKind.Local).AddTicks(8280), "Description", "Titulo", "Url" });

            migrationBuilder.InsertData(
                schema: "RssReader",
                table: "CategoryItemKey",
                columns: new[] { "Id", "CategoryForeignKey", "ItemForeignKey" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemKey_Category_CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "CategoryForeignKey",
                principalSchema: "RssReader",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemKey_Item_CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "CategoryForeignKey",
                principalSchema: "RssReader",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemKey_Category_CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryItemKey_Item_CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_CategoryItemId",
                schema: "RssReader",
                table: "CategoryItemKey");

            migrationBuilder.DeleteData(
                schema: "RssReader",
                table: "CategoryItemKey",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "RssReader",
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "RssReader",
                table: "Item",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ItemForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryItemKey_CategoryForeignKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                newName: "IX_CategoryItemKey_CategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "CreationDate",
                schema: "RssReader",
                table: "Item",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryItemKey",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItemKey_ItemId",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemKey_Category_CategoryId",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "CategoryId",
                principalSchema: "RssReader",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryItemKey_Item_ItemId",
                schema: "RssReader",
                table: "CategoryItemKey",
                column: "ItemId",
                principalSchema: "RssReader",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
