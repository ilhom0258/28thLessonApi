using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    InsertDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 1, "-''_|_/-", new DateTime(2020, 5, 29, 14, 42, 39, 55, DateTimeKind.Local).AddTicks(5733), "Если ты устал, то присять" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 2, "-''_|_/-", new DateTime(2020, 5, 29, 14, 42, 39, 56, DateTimeKind.Local).AddTicks(593), "Если ты покушал, то делай свое дело" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 3, "-''_|_/-", new DateTime(2020, 5, 29, 14, 42, 39, 56, DateTimeKind.Local).AddTicks(620), "Если ты не хочешь работать, то не работай" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 4, "-''_|_/-", new DateTime(2020, 5, 29, 14, 42, 39, 56, DateTimeKind.Local).AddTicks(623), "Если ты хочешь пить, то открой кран и выпей" });

            migrationBuilder.InsertData(
                table: "Quotes",
                columns: new[] { "Id", "Author", "InsertDate", "Text" },
                values: new object[] { 5, "-''_|_/-", new DateTime(2020, 5, 29, 14, 42, 39, 56, DateTimeKind.Local).AddTicks(625), "Если ты хочешь есть, то открой холодильник" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quotes");
        }
    }
}
