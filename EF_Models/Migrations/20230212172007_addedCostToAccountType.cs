using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcoreTesting.Migrations
{
    public partial class addedCostToAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "AccountTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: 1,
                column: "Cost",
                value: 12.99m);

            migrationBuilder.UpdateData(
                table: "AccountTypes",
                keyColumn: "AccountTypeID",
                keyValue: 2,
                column: "Cost",
                value: 129.99m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "AccountTypes");
        }
    }
}
