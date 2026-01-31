using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Restrichef.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteSeedERelacionamentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("99999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "RestricoesAlimentares",
                keyColumn: "Id",
                keyValue: new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
