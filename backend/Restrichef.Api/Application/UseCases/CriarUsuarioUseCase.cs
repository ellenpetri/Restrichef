using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class CriarUsuarioUseCase
{
    public User Executar(string nome, string email, string senha)
    {
        var user = new User(nome, email, senha);

        return user;
    }
}
