using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 1, "SYSTEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the description for Leg Press", "SYSTEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leg Press" });

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "Description", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[] { 2, "SYSTEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "This is the description for Deadlift", "SYSTEM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deadlift" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");
        }
    }
}
