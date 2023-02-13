using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFcoreTesting.Migrations
{
    public partial class DeletedAccountPaymentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPayments");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_AccountID",
                table: "Payments",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Accounts_AccountID",
                table: "Payments",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Accounts_AccountID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_AccountID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Payments");

            migrationBuilder.CreateTable(
                name: "AccountPayments",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    PaymentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPayments", x => new { x.AccountID, x.PaymentID });
                    table.ForeignKey(
                        name: "FK_AccountPayments_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPayments_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "PaymentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPayments_PaymentID",
                table: "AccountPayments",
                column: "PaymentID");
        }
    }
}
