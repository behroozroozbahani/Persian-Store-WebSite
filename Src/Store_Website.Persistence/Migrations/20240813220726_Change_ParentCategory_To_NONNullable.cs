using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_Website.Persistence.Migrations
{
    public partial class Change_ParentCategory_To_NONNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 8, 13, 15, 7, 26, 541, DateTimeKind.Local).AddTicks(5607));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 8, 13, 15, 7, 26, 541, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 8, 13, 15, 7, 26, 541, DateTimeKind.Local).AddTicks(5668));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "InsertTime",
                value: new DateTime(2024, 8, 13, 14, 47, 55, 544, DateTimeKind.Local).AddTicks(1067));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "InsertTime",
                value: new DateTime(2024, 8, 13, 14, 47, 55, 544, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "InsertTime",
                value: new DateTime(2024, 8, 13, 14, 47, 55, 544, DateTimeKind.Local).AddTicks(1125));
        }
    }
}
