namespace Restrichef.Api.Domain.Entities;

public class Receita
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public int TempoMinutos { get; private set; }
    public int Porcoes { get; private set; }

    public List<IngredienteReceita> Ingredientes { get; private set; } = [];
    public List<PassoPreparo> PassosPreparo { get; private set; } = [];

    protected Receita() { }

    public Receita(string nome, string descricao, int tempoMinutos, int porcoes)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        TempoMinutos = tempoMinutos;
        Porcoes = porcoes;
    }
}
