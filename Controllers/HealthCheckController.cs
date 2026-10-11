using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
public class HealthCheckController : ControllerBase
{
    [HttpGet("/health-check")]
    public IActionResult HealthCheck()
    {
        return Ok("ok");
    }
}
