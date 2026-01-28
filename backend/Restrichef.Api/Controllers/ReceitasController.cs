using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restrichef.Api.Application.UseCases;
using Restrichef.Api.Controllers.Dtos;
using Restrichef.Api.Domain.Entities;
using Restrichef.Api.Infrastructure.Data;
using System.Security.Claims;

namespace Restrichef.Api.Controllers;

[ApiController]
[Route("api/receitas")]
[Authorize]
public class ReceitasController(RestrichefDbContext context, FiltrarReceitasPorPerfilUseCase useCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        PerfilAlimentar? perfil = await context.PerfisAlimentares.Include(p => p.Restricoes).FirstOrDefaultAsync(p => p.UserId == userId);

        if (perfil == null)
            return Ok(new List<ReceitaListagemResponse>());

        List<Receita> receitas = await context.Receitas.Include(r => r.Ingredientes).ThenInclude(ir => ir.Ingrediente).ThenInclude(i => i.Restricoes).ToListAsync();

        List<Receita> resultado = useCase.Executar(receitas, perfil);

        List<ReceitaListagemResponse> response = [.. resultado
            .Select(receita => new ReceitaListagemResponse
            {
                Id = receita.Id,
                Nome = receita.Nome,
                Descricao = receita.Descricao,

                Tempo = $"{receita.TempoMinutos} min",
                Porcoes = $"Serve {receita.Porcoes} pessoas",

                Tags = [.. receita.Ingredientes
                    .SelectMany(ir => ir.Ingrediente.Restricoes)
                    .Select(r => r.Nome)
                    .Distinct()]
            })];

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Detalhar(Guid id)
    {
        Guid userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

        PerfilAlimentar? perfil = await context.PerfisAlimentares.Include(p => p.Restricoes).FirstOrDefaultAsync(p => p.UserId == userId);

        Receita? receita = await context.Receitas
            .Include(r => r.Ingredientes)
                .ThenInclude(ir => ir.Ingrediente)
                    .ThenInclude(i => i.Restricoes)
            .Include(r => r.PassosPreparo)
            .FirstOrDefaultAsync(r => r.Id == id);

        if (receita == null)
            return NotFound();

        List<string> restricoesDaReceita = [.. receita.Ingredientes.SelectMany(ir => ir.Ingrediente.Restricoes).Select(r => r.Nome).Distinct()];

        List<string> restricoesDoPerfil = perfil?.Restricoes.Select(r => r.Nome).ToList() ?? [];

        bool contemRestricoes = restricoesDaReceita.Any(r => restricoesDoPerfil.Contains(r));

        List<string> adequadoPara = [.. restricoesDoPerfil.Where(r => !restricoesDaReceita.Contains(r)).Select(r => $"Sem {r.ToLower()}")];

        ReceitaDetalheResponse response = new()
        {
            Id = receita.Id,
            Nome = receita.Nome,
            Descricao = receita.Descricao,

            Tempo = $"{receita.TempoMinutos} min",
            Porcoes = $"Serve {receita.Porcoes} pessoas",

            Ingredientes = [.. receita.Ingredientes
                .Select(ir => new IngredienteResponse
                {
                    Nome = ir.Ingrediente.Nome,
                    Quantidade = $"{ir.Quantidade} {ir.Unidade}"
                })],

            PassosPreparo = [.. receita.PassosPreparo.OrderBy(p => p.Ordem).Select(p => p.Descricao)],

            AdequadoPara = adequadoPara,
            ContemRestricoes = contemRestricoes
        };

        return Ok(response);
    }
}