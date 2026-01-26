using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.UseCases;

public class ObterPerfilAlimentarUseCase(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<PerfilAlimentar?> Executar(Guid userId)
    {
        User? user = await _userRepository.GetByIdAsync(userId);

        return user?.PerfilAlimentar;
    }
}
