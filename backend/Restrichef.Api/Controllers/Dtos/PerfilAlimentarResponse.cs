namespace Restrichef.Api.Controllers.Dtos;

public class PerfilAlimentarResponse
{
    public Guid UserId { get; set; }
    public List<Guid> RestricaoIds { get; set; } = [];
}
