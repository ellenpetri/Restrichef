using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restrichef.Api.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarFotoUrlReceita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoUrl",
                table: "Receitas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoUrl",
                table: "Receitas");
        }
    }
}
