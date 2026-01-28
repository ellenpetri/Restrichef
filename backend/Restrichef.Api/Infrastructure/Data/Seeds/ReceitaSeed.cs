using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Infrastructure.Data.Seeds;

public static class ReceitaSeed
{
    public static List<Receita> Criar(List<Ingrediente> ingredientes)
    {
        Ingrediente alface = ingredientes.First(i => i.Nome == "Alface");
        Ingrediente tomate = ingredientes.First(i => i.Nome == "Tomate");
        Ingrediente arroz = ingredientes.First(i => i.Nome == "Arroz");
        Ingrediente feijao = ingredientes.First(i => i.Nome == "Feijão");
        Ingrediente batata = ingredientes.First(i => i.Nome == "Batata");
        Ingrediente tofu = ingredientes.First(i => i.Nome == "Tofu");

        List<Receita> receitas = [];

        Receita salada = new("Salada Mediterrânea", "Salada leve e fresca", 10, 2);

        salada.Ingredientes.Add(new IngredienteReceita(alface, 2, "xícaras"));
        salada.Ingredientes.Add(new IngredienteReceita(tomate, 1, "unidade"));

        salada.PassosPreparo.Add(new PassoPreparo(1, "Lavar os vegetais."));
        salada.PassosPreparo.Add(new PassoPreparo(2, "Cortar e misturar."));

        receitas.Add(salada);

        Receita arrozFeijao = new("Arroz com Feijão", "Clássico brasileiro", 30, 4);

        arrozFeijao.Ingredientes.Add(new IngredienteReceita(arroz, 2, "xícaras"));
        arrozFeijao.Ingredientes.Add(new IngredienteReceita(feijao, 1, "xícara"));

        arrozFeijao.PassosPreparo.Add(new PassoPreparo(1, "Cozinhar o arroz."));
        arrozFeijao.PassosPreparo.Add(new PassoPreparo(2, "Cozinhar o feijão."));
        arrozFeijao.PassosPreparo.Add(new PassoPreparo(3, "Misturar e servir."));

        receitas.Add(arrozFeijao);

        Receita batataAssada = new("Batata Assada", "Batata crocante no forno", 40, 3);

        batataAssada.Ingredientes.Add(new IngredienteReceita(batata, 3, "unidades"));

        batataAssada.PassosPreparo.Add(new PassoPreparo(1, "Cortar as batatas."));
        batataAssada.PassosPreparo.Add(new PassoPreparo(2, "Assar até dourar."));

        receitas.Add(batataAssada);

        Receita tofuGrelhado = new("Tofu Grelhado", "Opção vegana rica em proteína", 20, 2);

        tofuGrelhado.Ingredientes.Add(new IngredienteReceita(tofu, 200, "gramas"));

        tofuGrelhado.PassosPreparo.Add(new PassoPreparo(1, "Aquecer a frigideira."));
        tofuGrelhado.PassosPreparo.Add(new PassoPreparo(2, "Grelhar o tofu."));

        receitas.Add(tofuGrelhado);

        Receita saladaSimples = new("Salada Simples", "Rápida para o dia a dia", 5, 1);

        saladaSimples.Ingredientes.Add(new IngredienteReceita(alface, 1, "xícara"));
        saladaSimples.Ingredientes.Add(new IngredienteReceita(tomate, 1, "unidade"));

        saladaSimples.PassosPreparo.Add(new PassoPreparo(1, "Misturar tudo."));

        receitas.Add(saladaSimples);

        Receita arrozSimples = new("Arroz Branco", "Base para várias refeições", 25, 4);

        arrozSimples.Ingredientes.Add(new IngredienteReceita(arroz, 2, "xícaras"));

        arrozSimples.PassosPreparo.Add(new PassoPreparo(1, "Cozinhar o arroz."));

        receitas.Add(arrozSimples);

        return receitas;
    }
}
