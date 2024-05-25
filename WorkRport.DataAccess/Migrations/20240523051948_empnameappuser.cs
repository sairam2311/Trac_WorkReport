using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class empnameappuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeName",
                table: "AspNetUsers");
        }
    }
}
