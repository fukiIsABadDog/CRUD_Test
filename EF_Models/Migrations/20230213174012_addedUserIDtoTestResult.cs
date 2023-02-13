using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcoreTesting.Migrations
{
    public partial class addedUserIDtoTestResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteUserSiteID",
                table: "TestResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteUserUserID",
                table: "TestResults",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "TestResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestResults_SiteUserSiteID_SiteUserUserID",
                table: "TestResults",
                columns: new[] { "SiteUserSiteID", "SiteUserUserID" });

            migrationBuilder.AddForeignKey(
                name: "FK_TestResults_SiteUsers_SiteUserSiteID_SiteUserUserID",
                table: "TestResults",
                columns: new[] { "SiteUserSiteID", "SiteUserUserID" },
                principalTable: "SiteUsers",
                principalColumns: new[] { "SiteID", "UserID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestResults_SiteUsers_SiteUserSiteID_SiteUserUserID",
                table: "TestResults");

            migrationBuilder.DropIndex(
                name: "IX_TestResults_SiteUserSiteID_SiteUserUserID",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "SiteUserSiteID",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "SiteUserUserID",
                table: "TestResults");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TestResults");
        }
    }
}
