using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRport.DataAccess.Migrations
{
    public partial class addingdesid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationDesId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_projectsProjectId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "projectsProjectId",
                table: "AspNetUsers",
                newName: "ProjectID");

            migrationBuilder.RenameColumn(
                name: "DesignationDesId",
                table: "AspNetUsers",
                newName: "DesignationID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_projectsProjectId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ProjectID");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DesignationDesId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DesignationID");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectID",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProjectID",
                table: "AspNetUsers",
                newName: "projectsProjectId");

            migrationBuilder.RenameColumn(
                name: "DesignationID",
                table: "AspNetUsers",
                newName: "DesignationDesId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ProjectID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_projectsProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DesignationID",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DesignationDesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Designations_DesignationDesId",
                table: "AspNetUsers",
                column: "DesignationDesId",
                principalTable: "Designations",
                principalColumn: "DesId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_projectsProjectId",
                table: "AspNetUsers",
                column: "projectsProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
