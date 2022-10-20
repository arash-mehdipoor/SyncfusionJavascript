using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SyncfusionJavascript.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "Age", "Birthdate", "City", "FirstName", "LastName", "Status" },
                values: new object[] { 1, "Address", 79, new DateTime(1943, 10, 20, 15, 7, 16, 74, DateTimeKind.Local).AddTicks(9929), "City", "Arash", "Mahdipour", true });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "Age", "Birthdate", "City", "FirstName", "LastName", "Status" },
                values: new object[] { 2, "Address", 22, new DateTime(2000, 10, 20, 15, 7, 16, 74, DateTimeKind.Local).AddTicks(9983), "City", "Roya", "Mirzavand", true });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "Age", "Birthdate", "City", "FirstName", "LastName", "Status" },
                values: new object[] { 3, "Address", 66, new DateTime(1956, 10, 20, 15, 7, 16, 74, DateTimeKind.Local).AddTicks(9988), "City", "Seyed", "Ramezani", true });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Address", "Age", "Birthdate", "City", "FirstName", "LastName", "Status" },
                values: new object[] { 4, "Address", 34, new DateTime(1988, 10, 20, 15, 7, 16, 75, DateTimeKind.Local).AddTicks(9), "City", "Sara", "Gohartoor", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
