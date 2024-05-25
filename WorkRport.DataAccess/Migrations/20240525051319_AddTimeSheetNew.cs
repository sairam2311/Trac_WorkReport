using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class AddTimeSheetNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "timeSheets",
                columns: table => new
                {
                    TSid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeGUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Work = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemarksBbyReOf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RemarksbyRpOf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeSheets", x => x.TSid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "timeSheets");
        }
    }
}
