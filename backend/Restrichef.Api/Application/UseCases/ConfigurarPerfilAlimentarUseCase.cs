using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class ConfigurarPerfilAlimentarUseCase
{
    private readonly IUserRepository _userRepository;

    public ConfigurarPerfilAlimentarUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task Executar(Guid userId, IEnumerable<RestricaoAlimentar> restricoes)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            throw new InvalidOperationException("Usuário não encontrado");

        user.DefinirPerfilAlimentar(restricoes);

        await _userRepository.UpdateAsync(user);
    }
}
