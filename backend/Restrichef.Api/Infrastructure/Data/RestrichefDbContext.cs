using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data.Seeds;

namespace Restrichef.Api.Infrastructure.Data;

public class RestrichefDbContext(DbContextOptions<RestrichefDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<PerfilAlimentar> PerfisAlimentares => Set<PerfilAlimentar>();
    public DbSet<RestricaoAlimentar> RestricoesAlimentares => Set<RestricaoAlimentar>();

    public DbSet<Receita> Receitas => Set<Receita>();
    public DbSet<Ingrediente> Ingredientes => Set<Ingrediente>();
    public DbSet<IngredienteReceita> IngredientesReceita => Set<IngredienteReceita>();
    public DbSet<PassoPreparo> PassosPreparo => Set<PassoPreparo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();

        // PerfilAlimentar <-> RestricaoAlimentar
        modelBuilder.Entity<PerfilAlimentar>().HasMany(p => p.Restricoes).WithMany().UsingEntity(j => j.ToTable("PerfilAlimentarRestricoes"));

        // Seed de restrições
        modelBuilder.Entity<RestricaoAlimentar>().HasData(RestricaoAlimentarSeed.Dados);

        // Receita -> IngredienteReceita
        modelBuilder.Entity<Receita>().HasMany(r => r.Ingredientes).WithOne().HasForeignKey(ir => ir.ReceitaId);

        // IngredienteReceita -> Ingrediente
        modelBuilder.Entity<IngredienteReceita>().HasOne(ir => ir.Ingrediente).WithMany().HasForeignKey(ir => ir.IngredienteId);

        // Receita -> PassoPreparo
        modelBuilder.Entity<Receita>().HasMany(r => r.PassosPreparo).WithOne().HasForeignKey(p => p.ReceitaId);

        // Ingrediente <-> RestricaoAlimentar
        modelBuilder.Entity<Ingrediente>().HasMany(i => i.Restricoes).WithMany().UsingEntity(j => j.ToTable("IngredienteRestricoes"));
    }
}
