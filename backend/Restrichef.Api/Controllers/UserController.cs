using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Application.Repositories;
using Restrichef.Api.Application.Security;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Controllers.Dtos;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;
using System.Security.Claims;

namespace Restrichef.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(CriarUsuarioUseCase criarUsuarioUseCase, LoginUsuarioUseCase loginUsuarioUseCase, JwtTokenService jwtTokenService) : ControllerBase
{
    private readonly CriarUsuarioUseCase _criarUsuarioUseCase = criarUsuarioUseCase;
    private readonly LoginUsuarioUseCase _loginUsuarioUseCase = loginUsuarioUseCase;
    private readonly JwtTokenService _jwtTokenService = jwtTokenService;

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

            string token = _jwtTokenService.GerarToken(user);

            return Ok(new { token });
        }
        catch (InvalidOperationException ex)
        {
            return Unauthorized(new { mensagem = ex.Message });
        }
    }

    [Authorize]
    [HttpPost("perfil-alimentar")]
    public async Task<IActionResult> ConfigurarPerfilAlimentar([FromBody] ConfigurarPerfilAlimentarRequest request, [FromServices] ConfigurarPerfilAlimentarUseCase useCase)
    {
        Guid userId = Guid.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        await useCase.Executar(userId, request.RestricaoIds);
        return NoContent();
    }

    [Authorize]
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

    [Authorize]
    [HttpGet("perfil-alimentar")]
    public async Task<IActionResult> ObterPerfilAlimentar([FromServices] IUserRepository userRepository)
    {
        Guid userId = Guid.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

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
