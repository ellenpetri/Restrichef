namespace Restrichef.Api.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Senha { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public PerfilAlimentar PerfilAlimentar { get; private set; }

    protected User() { }

    public User(string nome, string email, string senha)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Senha = senha;
        DataCriacao = DateTime.UtcNow;
    }

    public void DefinirPerfilAlimentar(IEnumerable<RestricaoAlimentar> restricoes)
    {
        PerfilAlimentar = new PerfilAlimentar(Id, restricoes);
    }

    public bool PossuiPerfilAlimentar()
    {
        return PerfilAlimentar != null;
    }
}
