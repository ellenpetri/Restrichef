using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class FiltrarReceitasPorPerfilUseCase
{
    public List<Receita> Executar(List<Receita> receitas, PerfilAlimentar perfil)
    {
        return [.. receitas
            .Where(receita =>
                receita.Ingredientes.All(ir =>
                    !ir.Ingrediente.Restricoes.Any(r =>
                        perfil.Restricoes.Any(pr => pr.Id == r.Id)
                    )
                )
            )];
    }
}
