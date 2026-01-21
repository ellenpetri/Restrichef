namespace Restrichef.Api.Domain.Entities;

public class PerfilAlimentar
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public IReadOnlyCollection<RestricaoAlimentar> Restricoes => _restricoes;
    private readonly List<RestricaoAlimentar> _restricoes = [];

    protected PerfilAlimentar() { }

    public PerfilAlimentar(Guid userId, IEnumerable<RestricaoAlimentar> restricoes)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        _restricoes.AddRange(restricoes);
    }

    public void AdicionarRestricao(RestricaoAlimentar restricao)
    {
        if (!_restricoes.Contains(restricao))
            _restricoes.Add(restricao);
    }

    public void RemoverRestricao(RestricaoAlimentar restricao)
    {
        _restricoes.Remove(restricao);
    }
}
