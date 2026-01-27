using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.Security;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class LoginUsuarioUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> Executar(string email, string senha)
    {
        User? user = await _userRepository.GetByEmailAsync(email);

        if (user == null)
            throw new InvalidOperationException("E-mail ou senha inválidos.");

        bool senhaValida = PasswordHasher.Verify(senha, user.Senha);

        if (!senhaValida)
            throw new InvalidOperationException("E-mail ou senha inválidos.");

        return user;
    }
}