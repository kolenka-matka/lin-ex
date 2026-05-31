using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers;

// Контроллер №3 — проверка сервиса (Health Check)
[ApiController]
[Route("[controller]")]
public class HealthController : ControllerBase
{
    // GET /health  -> 200 OK
    [HttpGet]
    public IActionResult Get() => Ok(new
    {
        status = "Healthy",
        time = DateTime.UtcNow
    });
}
