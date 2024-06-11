using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class timesheettitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkTitle",
                table: "timeSheets",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkTitle",
                table: "timeSheets");
        }
    }
}
