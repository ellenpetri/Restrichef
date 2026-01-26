namespace Restrichef.Api.Controllers.Dtos;

public class ConfigurarPerfilAlimentarRequest
{
    public Guid UserId { get; set; }
    public List<Guid> RestricaoIds { get; set; } = [];
}