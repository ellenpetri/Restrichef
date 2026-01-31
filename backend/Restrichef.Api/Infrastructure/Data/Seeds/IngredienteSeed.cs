using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Infrastructure.Data.Seeds;

public static class IngredienteSeed
{
    public static List<Ingrediente> Criar(List<RestricaoAlimentar> restricoesExistentes)
    {
        RestricaoAlimentar Get(string nome)
            => restricoesExistentes.First(r => r.Nome == nome);

        RestricaoAlimentar gluten = Get("Glúten");
        RestricaoAlimentar lactose = Get("Lactose");
        RestricaoAlimentar ovo = Get("Ovo");
        RestricaoAlimentar soja = Get("Soja");
        RestricaoAlimentar amendoim = Get("Amendoim");
        RestricaoAlimentar nozes = Get("Nozes e castanhas");
        RestricaoAlimentar frutosMar = Get("Frutos do mar");
        RestricaoAlimentar carneVermelha = Get("Carne vermelha");
        RestricaoAlimentar vegano = Get("Vegano");
        RestricaoAlimentar vegetariano = Get("Vegetariano");

        return
        [
            new("Arroz", []),
            new("Feijão", []),
            new("Alface", []),
            new("Tomate", []),
            new("Cebola", []),
            new("Batata", []),
            new("Azeite de Oliva", []),
            new("Sal", []),
            new("Alho", []),
            new("Cenoura", []),
            new("Abobrinha", []),
            new("Pimentão", []),
            new("Espinafre", []),
            new("Quinoa", []),
            new("Grão-de-bico", []),
            new("Lentilha", []),

            new("Farinha de Trigo", [gluten]),
            new("Macarrão Penne", [gluten]),
            new("Massa de Lasanha", [gluten]),

            new("Leite Integral", [lactose, vegano]),
            new("Creme de Leite", [lactose, vegano]),
            new("Queijo Mussarela", [lactose, vegano]),
            new("Queijo Parmesão", [lactose, vegano]),
            new("Manteiga", [lactose, vegano]),

            new("Ovos", [ovo, vegano]),

            new("Carne Moída", [carneVermelha, vegano, vegetariano]),
            new("Bacon", [carneVermelha, vegano, vegetariano]),
            new("Peito de Frango", [vegano, vegetariano]),

            new("Filé de Salmão", [frutosMar, vegano, vegetariano]),

            new("Leite Vegetal", []),
            new("Açúcar", []),
            new("Chocolate 70%", []),
            new("Fermento Químico", [])
        ];
    }
}
