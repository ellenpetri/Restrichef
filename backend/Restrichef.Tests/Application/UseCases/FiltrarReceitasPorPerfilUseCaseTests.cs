using FluentAssertions;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Tests.Application.UseCases;

public class FiltrarReceitasPorPerfilUseCaseTests
{
    [Fact]
    public void Deve_retornar_receita_quando_nao_ha_conflito_com_o_perfil()
    {
        RestricaoAlimentar lactose = new("Lactose", "Derivados de leite");

        PerfilAlimentar perfil = new(Guid.NewGuid(), [lactose]);

        Ingrediente farinha = new("Farinha", []);

        IngredienteReceita ingredienteReceita = new(farinha, 100, "g");

        Receita receita = new("Pão", "Pão simples", 60, 4);

        receita.Ingredientes.Add(ingredienteReceita);

        List<Receita> receitas = [receita];

        FiltrarReceitasPorPerfilUseCase useCase = new();

        List<Receita> resultado = useCase.Executar(receitas, perfil);

        resultado.Should().ContainSingle();
        resultado.First().Should().Be(receita);
    }

    [Fact]
    public void Deve_remover_receita_quando_ingrediente_conflita_com_o_perfil()
    {
        RestricaoAlimentar lactose = new("Lactose", "Derivados de leite");

        PerfilAlimentar perfil = new(Guid.NewGuid(), [lactose]);

        Ingrediente queijo = new("Queijo", [lactose]);

        IngredienteReceita ingredienteReceita = new(queijo, 50, "g");

        Receita receita = new("Pizza", "Pizza com queijo", 30, 2);

        receita.Ingredientes.Add(ingredienteReceita);

        List<Receita> receitas = [receita];

        FiltrarReceitasPorPerfilUseCase useCase = new();

        List<Receita> resultado = useCase.Executar(receitas, perfil);

        resultado.Should().BeEmpty();
    }

    [Fact]
    public void Deve_remover_receita_quando_qualquer_restricao_do_perfil_conflitar()
    {
        RestricaoAlimentar lactose = new("Lactose", "Derivados de leite");
        RestricaoAlimentar gluten = new("Glúten", "Derivados de trigo");

        PerfilAlimentar perfil = new(Guid.NewGuid(), [lactose, gluten]);

        Ingrediente farinha = new("Farinha de trigo", [gluten]);

        IngredienteReceita ingredienteReceita = new(farinha, 100, "g");

        Receita receita = new("Bolo", "Bolo simples", 45, 6);
        receita.Ingredientes.Add(ingredienteReceita);

        List<Receita> receitas = [receita];

        FiltrarReceitasPorPerfilUseCase useCase = new();

        List<Receita> resultado = useCase.Executar(receitas, perfil);

        resultado.Should().BeEmpty();
    }

    [Fact]
    public void Deve_retornar_todas_as_receitas_quando_perfil_nao_possui_restricoes()
    {
        PerfilAlimentar perfil = new(Guid.NewGuid(), []);

        RestricaoAlimentar lactose = new("Lactose", "Derivados de leite");

        Ingrediente leite = new("Leite", [lactose]);
        Ingrediente farinha = new("Farinha", []);

        IngredienteReceita ir1 = new(leite, 200, "ml");
        IngredienteReceita ir2 = new(farinha, 100, "g");

        Receita receita1 = new("Vitamina", "Vitamina de leite", 5, 1);
        receita1.Ingredientes.Add(ir1);

        Receita receita2 = new("Pão", "Pão simples", 60, 4);
        receita2.Ingredientes.Add(ir2);

        List<Receita> receitas = [receita1, receita2];

        FiltrarReceitasPorPerfilUseCase useCase = new();

        List<Receita> resultado = useCase.Executar(receitas, perfil);

        resultado.Should().HaveCount(2);
        resultado.Should().Contain(recipes => recipes == receita1);
        resultado.Should().Contain(recipes => recipes == receita2);
    }

}
