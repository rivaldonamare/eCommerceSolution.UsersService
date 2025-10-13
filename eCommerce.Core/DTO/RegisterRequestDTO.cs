namespace eCommerce.Core.DTO;

public record RegisterRequestDTO(string Name, string Email, string Password, GenderOptions Gender);

