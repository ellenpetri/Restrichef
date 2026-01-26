using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Infrastructure.Data;
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

builder.Services.AddDbContext<RestrichefDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<CriarUsuarioUseCase>();
builder.Services.AddScoped<ConfigurarPerfilAlimentarUseCase>();
builder.Services.AddScoped<ObterPerfilAlimentarUseCase>();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
