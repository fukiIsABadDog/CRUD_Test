using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcoreTesting.Migrations
{
    public partial class AddedSeedDataForAccounttesting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountStandings",
                columns: new[] { "AccountStandingID", "Name" },
                values: new object[,]
                {
                    { 1, "Current" },
                    { 2, "NotCurrent" }
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeID", "Name", "TermLengthDays" },
                values: new object[,]
                {
                    { 1, "PremiumMonthly", 30 },
                    { 2, "PremiumYearly", 365 },
                    { 3, "Trail", 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountStandings",
                keyColumn: "AccountStandingID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountStandings",
                keyColumn: "AccountStandingID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: 3);
        }
    }
}
