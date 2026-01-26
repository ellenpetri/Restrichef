using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Controllers.Dtos;

public class ConfigurarPerfilAlimentarRequest
{
    public Guid UserId { get; set; }
    public List<RestricaoAlimentar> Restricoes { get; set; } = [];
}
