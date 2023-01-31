using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceCenterLib.Orm.Migrations
{
    /// <inheritdoc />
    public partial class TransactionLineUpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_EngineerID",
                table: "TransactionLines",
                column: "EngineerID");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLines_ServiceTaskID",
                table: "TransactionLines",
                column: "ServiceTaskID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_Engineers_EngineerID",
                table: "TransactionLines",
                column: "EngineerID",
                principalTable: "Engineers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionLines_ServiceTasks_ServiceTaskID",
                table: "TransactionLines",
                column: "ServiceTaskID",
                principalTable: "ServiceTasks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_Engineers_EngineerID",
                table: "TransactionLines");

            migrationBuilder.DropForeignKey(
                name: "FK_TransactionLines_ServiceTasks_ServiceTaskID",
                table: "TransactionLines");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLines_EngineerID",
                table: "TransactionLines");

            migrationBuilder.DropIndex(
                name: "IX_TransactionLines_ServiceTaskID",
                table: "TransactionLines");
        }
    }
}
