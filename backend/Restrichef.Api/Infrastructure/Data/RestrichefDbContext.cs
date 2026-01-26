using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Infrastructure.Data;

public class RestrichefDbContext(DbContextOptions<RestrichefDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<PerfilAlimentar> PerfisAlimentares => Set<PerfilAlimentar>();
    public DbSet<RestricaoAlimentar> RestricoesAlimentares => Set<RestricaoAlimentar>();
}
