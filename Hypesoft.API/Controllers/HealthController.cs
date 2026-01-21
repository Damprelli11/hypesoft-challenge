using Microsoft.AspNetCore.Mvc;

namespace Hypesoft.API.Controllers;

/// <summary>
/// Controller for health check endpoints.
/// Provides a simple endpoint to verify the API is running.
/// </summary>
[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    /// <summary>
    /// Performs a health check and returns the current status.
    /// </summary>
    /// <returns>An object containing the status and timestamp.</returns>
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new
        {
            status = "ok",
            timestamp = DateTime.UtcNow
        });
    }
}
