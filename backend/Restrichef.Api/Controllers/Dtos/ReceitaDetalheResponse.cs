namespace Restrichef.Api.Controllers.Dtos;

public class ReceitaDetalheResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    public string Tempo { get; set; } = string.Empty;
    public string Porcoes { get; set; } = string.Empty;

    public List<IngredienteResponse> Ingredientes { get; set; } = [];
    public List<string> PassosPreparo { get; set; } = [];
}

public class IngredienteResponse
{
    public string Nome { get; set; } = string.Empty;
    public string Quantidade { get; set; } = string.Empty;
}
