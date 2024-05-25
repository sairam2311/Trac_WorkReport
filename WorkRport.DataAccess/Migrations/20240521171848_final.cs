using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DesignationID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProjectID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DesignationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesignationID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DesignationID",
                table: "AspNetUsers",
                column: "DesignationID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProjectID",
                table: "AspNetUsers",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationID",
                table: "AspNetUsers",
                column: "DesignationID",
                principalTable: "Designations",
                principalColumn: "DesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectID",
                table: "AspNetUsers",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
