using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;

namespace Restrichef.Api.Application.Repositories;

public class UserRepository(RestrichefDbContext context) : IUserRepository
{
    private readonly RestrichefDbContext _context = context;

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.Include(u => u.PerfilAlimentar).ThenInclude(p => p.Restricoes).FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task UpdateAsync(User user)
    {
        if (user.PerfilAlimentar != null && _context.Entry(user.PerfilAlimentar).State == EntityState.Detached)
            _context.PerfisAlimentares.Add(user.PerfilAlimentar);

        await _context.SaveChangesAsync();
    }
}
