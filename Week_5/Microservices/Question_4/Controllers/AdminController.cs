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
        return Ok("Welcome to the admin dashboard. You have admin privileges!");
    }

    [HttpGet("reports")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminReports()
    {
        return Ok("Admin-specific reports data.");
    }
}