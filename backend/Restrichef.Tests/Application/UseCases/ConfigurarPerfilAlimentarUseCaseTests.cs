using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;

namespace Restrichef.Tests.Application.UseCases;

public class ConfigurarPerfilAlimentarUseCaseTests
{
    private static RestrichefDbContext CriarContextoEmMemoria()
    {
        DbContextOptions<RestrichefDbContext> options = new DbContextOptionsBuilder<RestrichefDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        RestrichefDbContext context = new(options);
        context.Database.EnsureCreated();
        return context;
    }

    [Fact]
    public async Task Deve_substituir_restricoes_quando_perfil_ja_existe()
    {
        RestrichefDbContext context = CriarContextoEmMemoria();

        RestricaoAlimentar lactose = context.RestricoesAlimentares.First(r => r.Nome == "Lactose");
        RestricaoAlimentar gluten = context.RestricoesAlimentares.First(r => r.Nome == "Glúten");

        User user = new("Ellen", "ellen@email.com", "hash");
        user.DefinirPerfilAlimentar(new PerfilAlimentar(user.Id, [lactose]));

        Mock<IUserRepository> userRepository = new();
        userRepository.Setup(r => r.GetByIdAsync(user.Id)).ReturnsAsync(user);

        ConfigurarPerfilAlimentarUseCase useCase = new(userRepository.Object, context);

        await useCase.Executar(user.Id, [gluten.Id]);

        user.PerfilAlimentar!.Restricoes.Should().ContainSingle();
        user.PerfilAlimentar.Restricoes.First().Id.Should().Be(gluten.Id);
    }

    [Fact]
    public async Task Deve_lancar_excecao_quando_usuario_nao_existir()
    {
        RestrichefDbContext context = CriarContextoEmMemoria();

        Mock<IUserRepository> userRepository = new();
        userRepository.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((User?)null);

        ConfigurarPerfilAlimentarUseCase useCase = new(userRepository.Object, context);

        Func<Task> act = async () => await useCase.Executar(Guid.NewGuid(), []);

        await act.Should().ThrowAsync<InvalidOperationException>().WithMessage("Usuário não encontrado");
    }

}
