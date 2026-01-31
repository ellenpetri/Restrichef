namespace Restrichef.Api.Controllers.Dtos;

public class RestricaoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = null!;
}
