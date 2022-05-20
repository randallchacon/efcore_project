using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcore_project.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Homework",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[] { new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"), null, 50, "Personal activities" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[] { new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"), null, 20, "Pending activities" });

            migrationBuilder.InsertData(
                table: "Homework",
                columns: new[] { "HomeworkId", "CategoryId", "CreationDate", "Description", "PriorityHomework", "Title" },
                values: new object[] { new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"), new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"), new DateTime(2022, 5, 19, 23, 20, 53, 64, DateTimeKind.Local).AddTicks(757), null, 1, "Payment of public services" });

            migrationBuilder.InsertData(
                table: "Homework",
                columns: new[] { "HomeworkId", "CategoryId", "CreationDate", "Description", "PriorityHomework", "Title" },
                values: new object[] { new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"), new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"), new DateTime(2022, 5, 19, 23, 20, 53, 64, DateTimeKind.Local).AddTicks(774), null, 0, "Finish watching movie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c100"));

            migrationBuilder.DeleteData(
                table: "Homework",
                keyColumn: "HomeworkId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c101"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c602"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c4e0d0e7-5f06-48c7-9246-11fe12f2c657"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Homework",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
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
