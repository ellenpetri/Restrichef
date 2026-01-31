using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.Security;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;
using Restrichef.Api.Infrastructure.Data.Seeds;
using System.Text;
using System.Text.Json.Serialization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RestrichefDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<CriarUsuarioUseCase>();
builder.Services.AddScoped<ConfigurarPerfilAlimentarUseCase>();
builder.Services.AddScoped<ObterPerfilAlimentarUseCase>();
builder.Services.AddScoped<LoginUsuarioUseCase>();
builder.Services.AddScoped<FiltrarReceitasPorPerfilUseCase>();
builder.Services.AddScoped<JwtTokenService>();

IConfigurationSection jwtSettings = builder.Configuration.GetSection("Jwt");

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"]!)
            ),

            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

WebApplication app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    RestrichefDbContext context = scope.ServiceProvider.GetRequiredService<RestrichefDbContext>();

    context.Database.Migrate();

    context.Database.ExecuteSqlRaw("DELETE FROM IngredientesReceita");
    context.Database.ExecuteSqlRaw("DELETE FROM PassosPreparo");

    context.Database.ExecuteSqlRaw("DELETE FROM IngredienteRestricoes");
    context.Database.ExecuteSqlRaw("DELETE FROM PerfilAlimentarRestricoes");

    context.Database.ExecuteSqlRaw("DELETE FROM Receitas");
    context.Database.ExecuteSqlRaw("DELETE FROM Ingredientes");
    context.Database.ExecuteSqlRaw("DELETE FROM RestricoesAlimentares");

    List<RestricaoAlimentar> restricoes = RestricaoAlimentarSeed.Dados
        .Select(r => new RestricaoAlimentar(
            nome: (string)r.GetType().GetProperty("Nome")!.GetValue(r)!,
            descricao: (string)r.GetType().GetProperty("Descricao")!.GetValue(r)!
        ))
        .ToList();

    context.RestricoesAlimentares.AddRange(restricoes);
    context.SaveChanges();

    restricoes = context.RestricoesAlimentares.ToList();

    List<Ingrediente> ingredientes = IngredienteSeed.Criar(restricoes);
    context.Ingredientes.AddRange(ingredientes);
    context.SaveChanges();

    ingredientes = context.Ingredientes.ToList();

    List<Receita> receitas = ReceitaSeed.Criar(ingredientes);
    context.Receitas.AddRange(receitas);
    context.SaveChanges();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("Frontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
