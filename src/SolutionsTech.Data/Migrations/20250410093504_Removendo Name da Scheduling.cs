using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovendoNamedaScheduling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Scheduling",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdUserType",
                table: "Users",
                column: "IdUserType");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdFormPayment",
                table: "Scheduling",
                column: "IdFormPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdTypeProcedure",
                table: "Scheduling",
                column: "IdTypeProcedure");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdUser",
                table: "Scheduling",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_FormPayment_IdFormPayment",
                table: "Scheduling",
                column: "IdFormPayment",
                principalTable: "FormPayment",
                principalColumn: "IdFormPayment",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_TypeProcedure_IdTypeProcedure",
                table: "Scheduling",
                column: "IdTypeProcedure",
                principalTable: "TypeProcedure",
                principalColumn: "IdTypeProcedure",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scheduling_Users_IdUser",
                table: "Scheduling",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserType_IdUserType",
                table: "Users",
                column: "IdUserType",
                principalTable: "UserType",
                principalColumn: "IdUserType",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_FormPayment_IdFormPayment",
                table: "Scheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_TypeProcedure_IdTypeProcedure",
                table: "Scheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_Scheduling_Users_IdUser",
                table: "Scheduling");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserType_IdUserType",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdUserType",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_IdFormPayment",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_IdTypeProcedure",
                table: "Scheduling");

            migrationBuilder.DropIndex(
                name: "IX_Scheduling_IdUser",
                table: "Scheduling");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Scheduling",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
