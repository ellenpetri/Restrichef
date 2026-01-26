using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.Security;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class CriarUsuarioUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> Executar(string nome, string email, string senha)
    {
        string senhaHash = PasswordHasher.Hash(senha);

        User user = new(nome, email, senhaHash);

        await _userRepository.AddAsync(user);

        return user;
    }
}
