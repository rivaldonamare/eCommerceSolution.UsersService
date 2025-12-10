namespace eCommerce.Infrastructure.Service;

public class ApplicationUserService : IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository;
    private readonly IMapper _mapper;
    public ApplicationUserService(IApplicationUserRepository applicationUserRepository, IMapper mapper)
    {
        _applicationUserRepository = applicationUserRepository ?? throw new ArgumentNullException(nameof(applicationUserRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<AuthenticationResponse> GetUserByUserId(Guid userId)
    {
        var user = await _applicationUserRepository.GetUserByUserId(userId);

        if (user == null)
        {
            return new AuthenticationResponse
            {
                IsSuccess = false
            };
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Token = "Token", IsSuccess = true };
    }

    public async Task<AuthenticationResponse?> Login(LoginRequestDTO loginRequest)
    {
        var user = await _applicationUserRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);

        if (user == null)
        {
            return null;
        }

        return _mapper.Map<AuthenticationResponse>(user) with { Token = "Token", IsSuccess = true };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequestDTO registerRequest)
    {
        var user = new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            Name = registerRequest.Name,
            Gender = registerRequest.Gender.ToString()
        };

        var registeredUser = await _applicationUserRepository.AddUser(user);

        if (registeredUser == null) 
            return null;

        return new AuthenticationResponse(registeredUser.UserId, registeredUser.Email, registeredUser.Name, registeredUser.Gender, "Token", true);
    }
}
