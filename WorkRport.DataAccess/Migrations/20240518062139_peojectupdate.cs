using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class peojectupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectNumber",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectNumber",
                table: "Projects");
        }
    }
}
