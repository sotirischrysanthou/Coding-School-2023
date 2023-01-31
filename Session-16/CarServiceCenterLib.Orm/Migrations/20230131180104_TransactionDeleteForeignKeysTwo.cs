using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceCenterLib.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TransactionDeleteForeignKeysTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cars_CarID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Managers_ManagerID",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cars_CarID",
                table: "Transactions",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Managers_ManagerID",
                table: "Transactions",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Cars_CarID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Managers_ManagerID",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Cars_CarID",
                table: "Transactions",
                column: "CarID",
                principalTable: "Cars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Customers_CustomerID",
                table: "Transactions",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Managers_ManagerID",
                table: "Transactions",
                column: "ManagerID",
                principalTable: "Managers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
