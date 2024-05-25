using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class AddEmployeeMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeMappings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewingOfficerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportingOfficerId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeMappings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeMappings");
        }
    }
}
