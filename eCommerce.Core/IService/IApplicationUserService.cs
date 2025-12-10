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

    /// <summary>
    /// Retrieves the authentication response for a user identified by the specified user ID.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose authentication information is to be retrieved.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see
    /// cref="AuthenticationResponse"/> for the specified user if found; otherwise, <see langword="null"/>.</returns>
    Task<AuthenticationResponse?> GetUserByUserId(Guid userId);
}
