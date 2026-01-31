namespace Restrichef.Api.Domain.Entities;

public class RestricaoAlimentar
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public string Descricao { get; private set; } = null!;

    protected RestricaoAlimentar() { }

    public RestricaoAlimentar(string nome, string descricao)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
    }
}
