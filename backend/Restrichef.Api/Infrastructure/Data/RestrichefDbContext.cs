using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data.Seeds;

namespace Restrichef.Api.Infrastructure.Data;

public class RestrichefDbContext(DbContextOptions<RestrichefDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<PerfilAlimentar> PerfisAlimentares => Set<PerfilAlimentar>();
    public DbSet<RestricaoAlimentar> RestricoesAlimentares => Set<RestricaoAlimentar>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        modelBuilder.Entity<PerfilAlimentar>().HasMany(p => p.Restricoes).WithMany().UsingEntity(j => j.ToTable("PerfilAlimentarRestricoes"));

        modelBuilder.Entity<RestricaoAlimentar>().HasData(RestricaoAlimentarSeed.Dados);
    }
}
