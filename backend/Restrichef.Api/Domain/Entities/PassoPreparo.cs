namespace Restrichef.Api.Domain.Entities;

public class PassoPreparo
{
    public Guid Id { get; private set; }
    public Guid ReceitaId { get; private set; }

    public int Ordem { get; private set; }
    public string Descricao { get; private set; }

    protected PassoPreparo() { }

    public PassoPreparo(int ordem, string descricao)
    {
        Id = Guid.NewGuid();
        Ordem = ordem;
        Descricao = descricao;
    }
}
