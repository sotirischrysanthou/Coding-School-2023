using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceCenterLib.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TransactionLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLine_Transactions_TransactionID",
                table: "TransactionLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionLine",
                table: "TransactionLine");

            migrationBuilder.RenameTable(
                name: "TransactionLine",
                newName: "TransactionLines");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionLine_TransactionID",
                table: "TransactionLines",
                newName: "IX_TransactionLines_TransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionLines",
                table: "TransactionLines",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionID",
                table: "TransactionLines",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Transactions_TransactionID",
                table: "TransactionLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionLines",
                table: "TransactionLines");

            migrationBuilder.RenameTable(
                name: "TransactionLines",
                newName: "TransactionLine");

            migrationBuilder.RenameIndex(
                name: "IX_TransactionLines_TransactionID",
                table: "TransactionLine",
                newName: "IX_TransactionLine_TransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionLine",
                table: "TransactionLine",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLine_Transactions_TransactionID",
                table: "TransactionLine",
                column: "TransactionID",
                principalTable: "Transactions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
