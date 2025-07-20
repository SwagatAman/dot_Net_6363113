using Microsoft.AspNetCore.Mvc;
using JwtAuthApi.Models;
using JwtAuthApi.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<TokenResponse> Login([FromBody] LoginRequest request)
    {
        var token = _authService.Authenticate(request.Username, request.Password);
        if (token == null)
            return Unauthorized();
        return Ok(new TokenResponse { Token = token });
    }
}
