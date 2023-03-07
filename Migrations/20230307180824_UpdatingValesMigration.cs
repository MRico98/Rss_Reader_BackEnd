using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rss_Reader_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingValesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "RssReader",
                table: "Category",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Category_Name",
                schema: "RssReader",
                table: "Category",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Category_Name",
                schema: "RssReader",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "RssReader",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
        }
    }
}
