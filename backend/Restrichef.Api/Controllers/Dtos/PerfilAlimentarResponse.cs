using Restrichef.Api.Domain.Entities;

namespace Restrichef.Api.Controllers.Dtos;

public class PerfilAlimentarResponse
{
    public Guid UserId { get; set; }
    public List<RestricaoAlimentar> Restricoes { get; set; } = [];
}
