namespace Restrichef.Api.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string Senha { get; private set; } = null!;
    public DateTime DataCriacao { get; private set; }

    public PerfilAlimentar PerfilAlimentar { get; private set; } = null!;

    protected User() { }

    public User(string nome, string email, string senha)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        Senha = senha;
        DataCriacao = DateTime.UtcNow;
    }

    public void DefinirPerfilAlimentar(PerfilAlimentar perfilAlimentar)
    {
        PerfilAlimentar = perfilAlimentar;
    }

    public bool PossuiPerfilAlimentar()
    {
        return PerfilAlimentar != null;
    }
}

