namespace Restrichef.Api.Domain.Entities;

public class IngredienteReceita
{
    public Guid Id { get; private set; }
    public Guid ReceitaId { get; private set; }
    public Guid IngredienteId { get; private set; }

    public decimal Quantidade { get; private set; }
    public string Unidade { get; private set; }

    public Ingrediente Ingrediente { get; private set; } = null!;

    protected IngredienteReceita() { }

    public IngredienteReceita(Ingrediente ingrediente, decimal quantidade, string unidade)
    {
        Id = Guid.NewGuid();
        Ingrediente = ingrediente;
        IngredienteId = ingrediente.Id;
        Quantidade = quantidade;
        Unidade = unidade;
    }
}
