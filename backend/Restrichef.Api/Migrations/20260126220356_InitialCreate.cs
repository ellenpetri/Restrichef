using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restrichef.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfisAlimentares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfisAlimentares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfisAlimentares_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestricoesAlimentares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerfilAlimentarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestricoesAlimentares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestricoesAlimentares_PerfisAlimentares_PerfilAlimentarId",
                        column: x => x.PerfilAlimentarId,
                        principalTable: "PerfisAlimentares",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfisAlimentares_UserId",
                table: "PerfisAlimentares",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestricoesAlimentares_PerfilAlimentarId",
                table: "RestricoesAlimentares",
                column: "PerfilAlimentarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestricoesAlimentares");

            migrationBuilder.DropTable(
                name: "PerfisAlimentares");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
