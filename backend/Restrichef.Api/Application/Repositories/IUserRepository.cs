using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Application.Repositories;

public interface IUserRepository
{
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}
