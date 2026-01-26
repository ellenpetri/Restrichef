using Microsoft.AspNetCore.Mvc;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Controllers.Dtos;
using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(CriarUsuarioUseCase criarUsuarioUseCase) : ControllerBase
{
    private readonly CriarUsuarioUseCase _criarUsuarioUseCase = criarUsuarioUseCase;

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioRequest request)
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

    [HttpPost("perfil-alimentar")]
    public async Task<IActionResult> ConfigurarPerfilAlimentar([FromBody] ConfigurarPerfilAlimentarRequest request, [FromServices] ConfigurarPerfilAlimentarUseCase useCase)
    {
        await useCase.Executar(request.UserId, request.Restricoes);

        return NoContent();
    }

    [HttpGet("{userId}/perfil-alimentar")]
    public async Task<IActionResult> ObterPerfilAlimentar(Guid userId, [FromServices] ObterPerfilAlimentarUseCase useCase)
    {
        PerfilAlimentar? perfil = await useCase.Executar(userId);

        if (perfil == null)
            return NotFound();

        PerfilAlimentarResponse response = new()
        {
            UserId = perfil.UserId,
            Restricoes = perfil.Restricoes.ToList()
        };

        return Ok(response);
    }
}
