using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class UpdateDateTimeKinds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemarksbyRpOf",
                table: "timeSheets",
                newName: "RemarksByRpOf");

            migrationBuilder.RenameColumn(
                name: "RemarksBbyReOf",
                table: "timeSheets",
                newName: "RemarksByReOf");

            migrationBuilder.Sql(
           @"UPDATE ""timeSheets"" 
              SET ""ReportDate"" = ""ReportDate"" AT TIME ZONE 'UTC',
                  ""CurrentDate"" = ""CurrentDate"" AT TIME ZONE 'UTC'
              WHERE ""ReportDate"" IS NOT NULL AND ""CurrentDate"" IS NOT NULL"
       );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RemarksByRpOf",
                table: "timeSheets",
                newName: "RemarksbyRpOf");

            migrationBuilder.RenameColumn(
                name: "RemarksByReOf",
                table: "timeSheets",
                newName: "RemarksBbyReOf");
        }
    }
}
