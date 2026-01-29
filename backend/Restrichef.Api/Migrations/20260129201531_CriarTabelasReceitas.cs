using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restrichef.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarTabelasReceitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteRestricoes",
                columns: table => new
                {
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RestricoesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteRestricoes", x => new { x.IngredienteId, x.RestricoesId });
                    table.ForeignKey(
                        name: "FK_IngredienteRestricoes_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteRestricoes_RestricoesAlimentares_RestricoesId",
                        column: x => x.RestricoesId,
                        principalTable: "RestricoesAlimentares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempoMinutos = table.Column<int>(type: "int", nullable: false),
                    Porcoes = table.Column<int>(type: "int", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IngredientesReceita",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IngredienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientesReceita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientesReceita_Ingredientes_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientesReceita_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PassosPreparo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassosPreparo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassosPreparo_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteRestricoes_RestricoesId",
                table: "IngredienteRestricoes",
                column: "RestricoesId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesReceita_IngredienteId",
                table: "IngredientesReceita",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientesReceita_ReceitaId",
                table: "IngredientesReceita",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_PassosPreparo_ReceitaId",
                table: "PassosPreparo",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_IngredienteId",
                table: "Receitas",
                column: "IngredienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredienteRestricoes");

            migrationBuilder.DropTable(
                name: "IngredientesReceita");

            migrationBuilder.DropTable(
                name: "PassosPreparo");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Ingredientes");
        }
    }
}
