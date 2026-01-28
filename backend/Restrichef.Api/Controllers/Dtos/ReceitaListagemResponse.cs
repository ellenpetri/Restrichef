namespace Restrichef.Api.Controllers.Dtos;

public class ReceitaListagemResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Tempo { get; set; } = string.Empty;
    public string Porcoes { get; set; } = string.Empty;

    public List<string> Tags { get; set; } = [];
}
