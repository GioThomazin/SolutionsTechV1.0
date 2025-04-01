using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class Adicionandobancodedados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_FormPayment_FormPaymentIdFormPayment",
                table: "Scheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Users_UserIdUser",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_FormPaymentIdFormPayment",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_UserIdUser",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "FormPaymentIdFormPayment",
                table: "Scheduling");

            migrationBuilder.RenameColumn(
                name: "UserIdUser",
                table: "Scheduling",
                newName: "IdTypeProcedure");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdTypeProcedure",
                table: "Scheduling",
                newName: "UserIdUser");

            migrationBuilder.AddColumn<long>(
                name: "FormPaymentIdFormPayment",
                table: "Scheduling",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_FormPaymentIdFormPayment",
                table: "Scheduling",
                column: "FormPaymentIdFormPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_UserIdUser",
                table: "Scheduling",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_FormPayment_FormPaymentIdFormPayment",
                table: "Scheduling",
                column: "FormPaymentIdFormPayment",
                principalTable: "FormPayment",
                principalColumn: "IdFormPayment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Users_UserIdUser",
                table: "Scheduling",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
