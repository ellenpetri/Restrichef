using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class CriarUsuarioUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> Executar(string nome, string email, string senha)
    {
        var user = new User(nome, email, senha);

        await _userRepository.AddAsync(user);

        return user;
    }
}
