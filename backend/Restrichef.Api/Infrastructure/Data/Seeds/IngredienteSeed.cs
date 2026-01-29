using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Infrastructure.Data.Seeds;

public static class IngredienteSeed
{
    public static List<Ingrediente> Criar(List<RestricaoAlimentar> restricoesExistentes)
    {
        RestricaoAlimentar GetTag(string nomeRestricao)
        {
            RestricaoAlimentar? restricao = restricoesExistentes.FirstOrDefault(r => r.Nome.Equals(nomeRestricao, StringComparison.OrdinalIgnoreCase));

            if (restricao == null)
            {
                return new RestricaoAlimentar("Não Encontrada", "Erro no Seed");
            }
            return restricao;
        }

        RestricaoAlimentar gluten = GetTag("Glúten");
        RestricaoAlimentar lactose = GetTag("Lactose");
        RestricaoAlimentar ovo = GetTag("Ovo");
        RestricaoAlimentar soja = GetTag("Soja");
        RestricaoAlimentar amendoim = GetTag("Amendoim");
        RestricaoAlimentar nozes = GetTag("Nozes e castanhas");
        RestricaoAlimentar frutosMar = GetTag("Frutos do mar");
        RestricaoAlimentar carneVermelha = GetTag("Carne vermelha");
        RestricaoAlimentar vegano = GetTag("Vegano");
        RestricaoAlimentar vegetariano = GetTag("Vegetariano");

        List<Ingrediente> ingredientes = [];

        ingredientes.Add(new Ingrediente("Arroz", []));
        ingredientes.Add(new Ingrediente("Feijão", []));
        ingredientes.Add(new Ingrediente("Alface", []));
        ingredientes.Add(new Ingrediente("Tomate", []));
        ingredientes.Add(new Ingrediente("Cebola", []));
        ingredientes.Add(new Ingrediente("Batata", []));
        ingredientes.Add(new Ingrediente("Azeite de Oliva", []));
        ingredientes.Add(new Ingrediente("Sal", []));

        ingredientes.Add(new Ingrediente("Farinha de Trigo", [gluten]));
        ingredientes.Add(new Ingrediente("Macarrão Penne", [gluten]));

        ingredientes.Add(new Ingrediente("Leite Integral", [lactose, vegano]));
        ingredientes.Add(new Ingrediente("Queijo Parmesão", [lactose, vegano]));
        ingredientes.Add(new Ingrediente("Creme de Leite", [lactose, vegano]));

        ingredientes.Add(new Ingrediente("Ovos", [ovo, vegano]));

        ingredientes.Add(new Ingrediente("Carne Moída", [carneVermelha, vegano, vegetariano]));
        ingredientes.Add(new Ingrediente("Bacon", [carneVermelha, vegano, vegetariano]));

        ingredientes.Add(new Ingrediente("Camarão", [frutosMar, vegano, vegetariano]));
        ingredientes.Add(new Ingrediente("Filé de Merluza", [frutosMar, vegano, vegetariano]));

        ingredientes.Add(new Ingrediente("Shoyu", [soja]));
        ingredientes.Add(new Ingrediente("Tofu", [soja]));

        ingredientes.Add(new Ingrediente("Pasta de Amendoim", [amendoim]));
        ingredientes.Add(new Ingrediente("Amendoim Torrado", [amendoim]));
        ingredientes.Add(new Ingrediente("Nozes", [nozes]));
        ingredientes.Add(new Ingrediente("Castanha de Caju", [nozes]));

        ingredientes.Add(new Ingrediente("Peito de Frango", [vegano, vegetariano]));

        return ingredientes;
    }
}