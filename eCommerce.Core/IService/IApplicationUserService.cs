namespace eCommerce.Core.IService;

public interface IApplicationUserService
{
    /// <summary>
    /// Method to handle user login and return authentication response
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequestDTO loginRequest);

    /// <summary>
    /// Method to handle user registration and return authentication response
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequestDTO registerRequest);
}
