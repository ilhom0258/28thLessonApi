using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBAPI.Migrations
{
    public partial class CorrectedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2020, 5, 30, 13, 42, 51, 840, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 2,
                column: "InsertDate",
                value: new DateTime(2020, 5, 30, 13, 42, 51, 841, DateTimeKind.Local).AddTicks(2069));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 3,
                column: "InsertDate",
                value: new DateTime(2020, 5, 30, 13, 42, 51, 841, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 4,
                column: "InsertDate",
                value: new DateTime(2020, 5, 30, 13, 42, 51, 841, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "Quotes",
                keyColumn: "Id",
                keyValue: 5,
                column: "InsertDate",
                value: new DateTime(2020, 5, 30, 13, 42, 51, 841, DateTimeKind.Local).AddTicks(2149));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
