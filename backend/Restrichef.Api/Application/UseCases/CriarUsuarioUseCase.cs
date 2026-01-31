using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.Security;
using Restrichef.Api.Domain.Entities;
using System.Net.Mail;

namespace Restrichef.Api.Application.UseCases;

public class CriarUsuarioUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<User> Executar(string nome, string email, string senha)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidOperationException("E-mail é obrigatório.");

        email = email.Trim().ToLowerInvariant();

        try
        {
            new MailAddress(email);
        }
        catch (FormatException)
        {
            throw new InvalidOperationException("E-mail em formato inválido.");
        }

        User? usuarioExistente = await _userRepository.GetByEmailAsync(email);

        if (usuarioExistente != null)
            throw new InvalidOperationException("Já existe um usuário cadastrado com este e-mail.");

        string senhaHash = PasswordHasher.Hash(senha);

        User user = new(nome, email, senhaHash);

        await _userRepository.AddAsync(user);

        return user;
    }
}
