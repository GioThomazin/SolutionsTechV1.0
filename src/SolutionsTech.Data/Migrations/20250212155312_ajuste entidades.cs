using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class ajusteentidades : Migration
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

            migrationBuilder.DropForeignKey(
                name: "FK_UserType_Users_UserIdUser",
                table: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_UserType_UserIdUser",
                table: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_FormPaymentIdFormPayment",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_UserIdUser",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "FormPaymentIdFormPayment",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Brand");

            migrationBuilder.AlterColumn<long>(
                name: "IdUserType",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtDesativation",
                table: "Scheduling",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtDesativation",
                table: "Product",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtDesativation",
                table: "FormPayment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtDesativation",
                table: "Brand",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtDesativation",
                table: "Scheduling");

            migrationBuilder.DropColumn(
                name: "DtDesativation",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DtDesativation",
                table: "FormPayment");

            migrationBuilder.DropColumn(
                name: "DtDesativation",
                table: "Brand");

            migrationBuilder.AddColumn<long>(
                name: "UserIdUser",
                table: "UserType",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IdUserType",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "FormPaymentIdFormPayment",
                table: "Scheduling",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserIdUser",
                table: "Scheduling",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Brand",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserType_UserIdUser",
                table: "UserType",
                column: "UserIdUser");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserType_Users_UserIdUser",
                table: "UserType",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }
    }
}
