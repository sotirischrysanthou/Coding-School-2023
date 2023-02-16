using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.EF.Migrations
{
    /// <inheritdoc />
    public partial class TransactionLinesCascadeFromTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionId",
                table: "TransactionLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionId",
                table: "TransactionLines",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionId",
                table: "TransactionLines");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionId",
                table: "TransactionLines",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
