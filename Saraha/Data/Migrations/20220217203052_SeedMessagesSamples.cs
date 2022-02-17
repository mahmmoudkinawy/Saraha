using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saraha.Data.Migrations
{
    public partial class SeedMessagesSamples : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "Created" },
                values: new object[] { 1, "Hello I Love you", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "Created" },
                values: new object[] { 2, "Play tinnes", new DateTime(2022, 2, 17, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
