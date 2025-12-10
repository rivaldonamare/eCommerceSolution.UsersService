namespace eCommerce.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService;

    public UsersController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService ?? throw new ArgumentNullException(nameof(applicationUserService));
    }

    [HttpGet("userId")] // api/v1/users/userId
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var user = await _applicationUserService.GetUserByUserId(userId);
        if (user == null)
            return NotFound("User not found.");

        return Ok(user);
    }
}
