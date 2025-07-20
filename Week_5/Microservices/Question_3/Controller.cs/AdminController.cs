using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("dashboard")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminDashboard()
    {
        return Ok("Welcome to the admin dashboard.");
    }

    [HttpGet("reports")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminReports()
    {
        return Ok("Admin reports data.");
    }
}