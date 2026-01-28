using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;

namespace Restrichef.Api.Application.UseCases;

public class ConfigurarPerfilAlimentarUseCase(IUserRepository userRepository, RestrichefDbContext context)
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly RestrichefDbContext _context = context;

    public async Task Executar(Guid userId, IEnumerable<Guid> restricaoIds)
    {
        User user = await _userRepository.GetByIdAsync(userId) ?? throw new InvalidOperationException("Usuário não encontrado");

        IEnumerable<Guid> ids = restricaoIds?.Where(id => id != Guid.Empty).Distinct() ?? [];

        List<RestricaoAlimentar> restricoes = await _context.RestricoesAlimentares.Where(r => ids.Contains(r.Id)).ToListAsync();

        if (user.PerfilAlimentar == null)
            user.DefinirPerfilAlimentar(new PerfilAlimentar(user.Id, restricoes));
        else
            user.PerfilAlimentar.SubstituirRestricoes(restricoes);

        await _userRepository.UpdateAsync(user);
    }

}
