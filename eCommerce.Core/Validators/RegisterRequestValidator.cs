namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequestDTO>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(50).WithMessage("Email must be at most 50 characters long.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").MaximumLength(50).WithMessage("Name must be at most 50 characters long.");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required.").IsInEnum().WithMessage("Invalid gender value.");
    }
}
