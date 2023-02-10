using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceCenterLib.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TransactionTransactionLinesOnDeleteClientCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionID",
                table: "TransactionLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionID",
                table: "TransactionLines",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionID",
                table: "TransactionLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionID",
                table: "TransactionLines",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
