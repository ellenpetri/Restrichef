namespace Restrichef.Api.Infrastructure.Data.Seeds;

public static class RestricaoAlimentarSeed
{
    public static object[] Dados =>
    [
        new
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Nome = "Glúten",
            Descricao = "Trigo, cevada, centeio e derivados"
        },
        new
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Nome = "Lactose",
            Descricao = "Leite e derivados"
        },
        new
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Nome = "Ovo",
            Descricao = "Ovos e derivados"
        },
        new
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
            Nome = "Soja",
            Descricao = "Soja e derivados"
        },
        new
        {
            Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
            Nome = "Amendoim",
            Descricao = "Amendoim e derivados"
        },
        new
        {
            Id = Guid.Parse("66666666-6666-6666-6666-666666666666"),
            Nome = "Nozes e castanhas",
            Descricao = "Castanhas, nozes e similares"
        },
        new
        {
            Id = Guid.Parse("77777777-7777-7777-7777-777777777777"),
            Nome = "Frutos do mar",
            Descricao = "Peixes e frutos do mar"
        },
        new
        {
            Id = Guid.Parse("88888888-8888-8888-8888-888888888888"),
            Nome = "Carne vermelha",
            Descricao = "Boi, porco e derivados"
        },
        new
        {
            Id = Guid.Parse("99999999-9999-9999-9999-999999999999"),
            Nome = "Vegano",
            Descricao = "Sem produtos de origem animal"
        },
        new
        {
            Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
            Nome = "Vegetariano",
            Descricao = "Sem carne, mas pode conter derivados animais"
        }
    ];
}