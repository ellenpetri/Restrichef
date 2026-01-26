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
}
