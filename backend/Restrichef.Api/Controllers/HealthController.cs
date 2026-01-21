using Microsoft.AspNetCore.Mvc;

namespace Restrichef.Api.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok("API running");
}
