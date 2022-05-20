using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcore_project.Migrations
{
    public partial class ColumnCategoryEffort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Effort",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Effort",
                table: "Category");
        }
    }
}
