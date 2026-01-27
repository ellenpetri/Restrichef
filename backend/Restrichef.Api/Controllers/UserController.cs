using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Controllers.Dtos;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;

namespace Restrichef.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(CriarUsuarioUseCase criarUsuarioUseCase, LoginUsuarioUseCase loginUsuarioUseCase) : ControllerBase
{
    private readonly CriarUsuarioUseCase _criarUsuarioUseCase = criarUsuarioUseCase;
    private readonly LoginUsuarioUseCase _loginUsuarioUseCase = loginUsuarioUseCase;

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioRequest request)
    {
        try
        {
            User user = await _criarUsuarioUseCase.Executar(
                request.Nome,
                request.Email,
                request.Senha
            );

            return CreatedAtAction(
                nameof(CriarUsuario),
                new { id = user.Id },
                null
            );
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { mensagem = ex.Message });
        }
        catch (DbUpdateException)
        {
            return Conflict(new { mensagem = "Já existe um usuário cadastrado com este e-mail." });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUsuarioRequest request)
    {
        try
        {
            User user = await _loginUsuarioUseCase.Executar(
                request.Email,
                request.Senha
            );

            return Ok(new { userId = user.Id });
        }
        catch (InvalidOperationException ex)
        {
            return Unauthorized(new { mensagem = ex.Message });
        }
    }

    [HttpPost("perfil-alimentar")]
    public async Task<IActionResult> ConfigurarPerfilAlimentar([FromBody] ConfigurarPerfilAlimentarRequest request, [FromServices] ConfigurarPerfilAlimentarUseCase useCase)
    {
        await useCase.Executar(request.UserId, request.RestricaoIds);
        return NoContent();
    }

    [HttpGet("restricoes")]
    public async Task<IActionResult> ObterRestricoes([FromServices] RestrichefDbContext context)
    {
        List<RestricaoResponse> restricoes = await context.RestricoesAlimentares
            .Select(r => new RestricaoResponse
            {
                Id = r.Id,
                Nome = r.Nome,
                Descricao = r.Descricao
            })
            .ToListAsync();

        return Ok(restricoes);
    }

    [HttpGet("{userId}/perfil-alimentar")]
    public async Task<IActionResult> ObterPerfilAlimentar(Guid userId, [FromServices] IUserRepository userRepository)
    {
        User? user = await userRepository.GetByIdAsync(userId);

        if (user == null || user.PerfilAlimentar == null)
            return Ok(new PerfilAlimentarResponse
            {
                UserId = userId,
                RestricaoIds = []
            });

        return Ok(new PerfilAlimentarResponse
        {
            UserId = userId,
            RestricaoIds = user.PerfilAlimentar.Restricoes.Select(r => r.Id).ToList()
        });
    }

}
