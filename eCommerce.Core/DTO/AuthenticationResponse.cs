namespace eCommerce.Core.DTO;

public record AuthenticationResponse(Guid UserId, string Email, string Name, string Gender, string Token, bool IsSuccess)
{
    public AuthenticationResponse() : this(default, string.Empty, string.Empty, string.Empty, string.Empty, false) { }
}