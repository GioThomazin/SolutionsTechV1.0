using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionsTech.Data.Migrations
{
    public partial class InserindocampoDatadeNascimento5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adiciona a coluna DataNascimento à tabela Users
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Users",
                type: "datetime2",
                nullable: true);  // Permite que o valor seja nulo
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove a coluna DataNascimento caso seja necessário desfazer a migração
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Users");
        }
    }
}
