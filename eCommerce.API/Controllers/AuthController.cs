namespace eCommerce.API.Controllers;

[Route("api/v1/[controller]")] // api/v1/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService;

    public AuthController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService ?? throw new ArgumentNullException(nameof(applicationUserService));
    }

    [HttpGet("ping")] // api/v1/auth/ping
    public IActionResult Ping()
    {
        return Ok("Pong");
    }

    [HttpPost("register")] // api/v1/auth/register
    public async Task<IActionResult> Register(RegisterRequestDTO registerRequestDTO)
    {
        // check for valid request
        if (registerRequestDTO == null)
            return BadRequest("Invalid registration request.");

        // call the service to register the user
        AuthenticationResponse? response = await _applicationUserService.Register(registerRequestDTO);

        // check for valid response
        if (response == null || !response.IsSuccess)
            return BadRequest("Registration failed. User may already exist.");

        return Ok(response);
    }

    [HttpPost("login")] // api/v1/auth/login
    public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
    {
        // check for valid request
        if (loginRequestDTO == null)
            return BadRequest("Invalid login request.");

        // call the service to login the user
        AuthenticationResponse? response = await _applicationUserService.Login(loginRequestDTO);

        // check for valid response
        if (response == null || !response.IsSuccess)
            return Unauthorized("Login failed. Invalid email or password.");

        return Ok(response);
    }
}
