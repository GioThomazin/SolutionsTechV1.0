using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class InserindocampoEmailnaUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserIdUser",
                table: "UserType",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserType_UserIdUser",
                table: "UserType",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserType_Users_UserIdUser",
                table: "UserType",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserType_Users_UserIdUser",
                table: "UserType");

            migrationBuilder.DropIndex(
                name: "IX_UserType_UserIdUser",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "UserType");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");
        }
    }
}
