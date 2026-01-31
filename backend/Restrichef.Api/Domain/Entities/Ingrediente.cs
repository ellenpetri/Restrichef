namespace Restrichef.Api.Domain.Entities;

public class Ingrediente
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public List<RestricaoAlimentar> Restricoes { get; private set; } = [];
    public ICollection<Receita> Receitas { get; private set; } = [];

    protected Ingrediente() { }

    public Ingrediente(string nome, List<RestricaoAlimentar> restricoes)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Restricoes = restricoes;
    }
}
