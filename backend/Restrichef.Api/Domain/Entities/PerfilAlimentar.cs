namespace Restrichef.Api.Domain.Entities;

public class PerfilAlimentar
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }

    public ICollection<RestricaoAlimentar> Restricoes { get; private set; } = [];

    protected PerfilAlimentar() { }

    public PerfilAlimentar(Guid userId, IEnumerable<RestricaoAlimentar> restricoes)
    {
        Id = Guid.NewGuid();
        UserId = userId;

        foreach (RestricaoAlimentar restricao in restricoes)
            Restricoes.Add(restricao);
    }

    public void SubstituirRestricoes(IEnumerable<RestricaoAlimentar> restricoes)
    {
        Restricoes.Clear();

        foreach (RestricaoAlimentar restricao in restricoes)
            Restricoes.Add(restricao);
    }
}
