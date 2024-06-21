using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entity_Framework.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryImpact", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1502"), null, 10, "Personal Activities " },
                    { new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1595"), null, 20, "Activities to Do" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "PriorityTask", "TaskDate", "TaskDescription", "TaskTitle" },
                values: new object[,]
                {
                    { new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1510"), new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1595"), 1, new DateTime(2024, 6, 11, 0, 9, 51, 592, DateTimeKind.Local).AddTicks(1888), null, "pay the internet" },
                    { new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1511"), new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1502"), 0, new DateTime(2024, 6, 11, 0, 9, 51, 592, DateTimeKind.Local).AddTicks(1912), null, "Wash My Shoes" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1510"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1511"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1502"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("3b085bfd-2240-4d4d-a6e8-e1f2155c1595"));

            migrationBuilder.AlterColumn<string>(
                name: "TaskDescription",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryDescription",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
