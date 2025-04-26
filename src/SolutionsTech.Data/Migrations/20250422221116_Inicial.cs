using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    IdBrand = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDesativation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.IdBrand);
                });

            migrationBuilder.CreateTable(
                name: "FormPayment",
                columns: table => new
                {
                    IdFormPayment = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDesativation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormPayment", x => x.IdFormPayment);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    IdProduct = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDesativation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdBrand = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.IdProduct);
                });

            migrationBuilder.CreateTable(
                name: "TypeProcedure",
                columns: table => new
                {
                    IdTypeProcedure = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProcedure", x => x.IdTypeProcedure);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    IdUserType = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.IdUserType);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtBorn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DtDeactivation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdUserType = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_UserType_IdUserType",
                        column: x => x.IdUserType,
                        principalTable: "UserType",
                        principalColumn: "IdUserType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scheduling",
                columns: table => new
                {
                    IdScheduling = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DtCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DtDesativation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    IdFormPayment = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduling", x => x.IdScheduling);
                    table.ForeignKey(
                        name: "FK_Scheduling_FormPayment_IdFormPayment",
                        column: x => x.IdFormPayment,
                        principalTable: "FormPayment",
                        principalColumn: "IdFormPayment",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scheduling_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulingProcedure",
                columns: table => new
                {
                    IdSchedulingProcedure = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdScheduling = table.Column<long>(type: "bigint", nullable: false),
                    IdTypeProcedure = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulingProcedure", x => x.IdSchedulingProcedure);
                    table.ForeignKey(
                        name: "FK_SchedulingProcedure_Scheduling_IdScheduling",
                        column: x => x.IdScheduling,
                        principalTable: "Scheduling",
                        principalColumn: "IdScheduling",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulingProduct",
                columns: table => new
                {
                    IdSchedulingProduct = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdScheduling = table.Column<long>(type: "bigint", nullable: false),
                    IdProduct = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulingProduct", x => x.IdSchedulingProduct);
                    table.ForeignKey(
                        name: "FK_SchedulingProduct_Scheduling_IdScheduling",
                        column: x => x.IdScheduling,
                        principalTable: "Scheduling",
                        principalColumn: "IdScheduling",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdFormPayment",
                table: "Scheduling",
                column: "IdFormPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduling_IdUser",
                table: "Scheduling",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProcedure_IdScheduling",
                table: "SchedulingProcedure",
                column: "IdScheduling");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulingProduct_IdScheduling",
                table: "SchedulingProduct",
                column: "IdScheduling");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdUserType",
                table: "Users",
                column: "IdUserType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "SchedulingProcedure");

            migrationBuilder.DropTable(
                name: "SchedulingProduct");

            migrationBuilder.DropTable(
                name: "TypeProcedure");

            migrationBuilder.DropTable(
                name: "Scheduling");

            migrationBuilder.DropTable(
                name: "FormPayment");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}
