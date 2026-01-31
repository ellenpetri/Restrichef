namespace Restrichef.Api.Controllers.Dtos;

public class ReceitaDetalheResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    public string Tempo { get; set; } = string.Empty;
    public string Porcoes { get; set; } = string.Empty;
    public string? FotoUrl { get; set; }
    public List<IngredienteResponse> Ingredientes { get; set; } = [];
    public List<string> PassosPreparo { get; set; } = [];

    public List<string> AdequadoPara { get; set; } = [];
    public bool ContemRestricoes { get; set; }
}

public class IngredienteResponse
{
    public string Nome { get; set; } = string.Empty;
    public string Quantidade { get; set; } = string.Empty;
}
