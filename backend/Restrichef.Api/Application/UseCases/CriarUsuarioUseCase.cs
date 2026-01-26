using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class CriarUsuarioUseCase
{
    public User Executar(string nome, string email, string senha)
    {
        User user = new(nome, email, senha);

        return user;
    }
}
