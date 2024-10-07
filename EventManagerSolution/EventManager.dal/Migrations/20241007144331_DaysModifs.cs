using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManager.dal.Migrations
{
    /// <inheritdoc />
    public partial class DaysModifs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Event_EventId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Theme_ThemeId",
                table: "Days");

            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Theme",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Science-fiction" },
                    { 3, "Medieval" }
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "EventId", "Name", "StartDate", "ThemeId" },
                values: new object[,]
                {
                    { 1, 9, "Manga Days", new DateOnly(2020, 5, 1), 3 },
                    { 2, 9, "Cosplay Days", new DateOnly(2020, 5, 2), 2 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Event_EventId",
                table: "Days",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Theme_ThemeId",
                table: "Days",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_Event_EventId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Theme_ThemeId",
                table: "Days");

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Theme",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "ThemeId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Event_EventId",
                table: "Days",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Theme_ThemeId",
                table: "Days",
                column: "ThemeId",
                principalTable: "Theme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
