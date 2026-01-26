using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class ConfigurarPerfilAlimentarUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Executar(Guid userId, IEnumerable<RestricaoAlimentar> restricoes)
    {
        User user = await _userRepository.GetByIdAsync(userId) ?? throw new InvalidOperationException("Usuário não encontrado");

        if (user.PerfilAlimentar == null)
            user.DefinirPerfilAlimentar(restricoes);
        else
            user.PerfilAlimentar.AtualizarRestricoes(restricoes);

        await _userRepository.UpdateAsync(user);
    }
}
