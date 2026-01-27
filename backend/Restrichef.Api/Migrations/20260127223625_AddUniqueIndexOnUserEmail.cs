using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restrichef.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueIndexOnUserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RestricoesAlimentares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestricoesAlimentares", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "PerfilAlimentarRestricoes",
                columns: table => new
                {
                    PerfilAlimentarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestricoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilAlimentarRestricoes", x => new { x.PerfilAlimentarId, x.RestricoesId });
                    table.ForeignKey(
                        name: "FK_PerfilAlimentarRestricoes_PerfisAlimentares_PerfilAlimentarId",
                        column: x => x.PerfilAlimentarId,
                        principalTable: "PerfisAlimentares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilAlimentarRestricoes_RestricoesAlimentares_RestricoesId",
                        column: x => x.RestricoesId,
                        principalTable: "RestricoesAlimentares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RestricoesAlimentares",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Trigo, cevada, centeio e derivados", "Glúten" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Leite e derivados", "Lactose" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Ovos e derivados", "Ovo" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Soja e derivados", "Soja" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Amendoim e derivados", "Amendoim" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Castanhas, nozes e similares", "Nozes e castanhas" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Peixes e frutos do mar", "Frutos do mar" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "Boi, porco e derivados", "Carne vermelha" },
                    { new Guid("99999999-9999-9999-9999-999999999999"), "Sem produtos de origem animal", "Vegano" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Sem carne, mas pode conter derivados animais", "Vegetariano" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PerfilAlimentarRestricoes_RestricoesId",
                table: "PerfilAlimentarRestricoes",
                column: "RestricoesId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfisAlimentares_UserId",
                table: "PerfisAlimentares",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilAlimentarRestricoes");

            migrationBuilder.DropTable(
                name: "PerfisAlimentares");

            migrationBuilder.DropTable(
                name: "RestricoesAlimentares");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
