
namespace RegisterationTask.Validations;

public class RegisterDtoValidation : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidation()
    {
        RuleFor(x=>x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required")
            .MinimumLength(2)
            .WithMessage("First Name must be at least 2 characters long")
            .MaximumLength(50)
            .WithMessage("First Name must not exceed 50 characters");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required")
            .MinimumLength(2)
            .WithMessage("Last Name must be at least 2 characters long")
            .MaximumLength(50)
            .WithMessage("Last Name must not exceed 50 characters");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email must be a valid email address");
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Matches(RegexPatterns.Password);
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required")
            .Matches(@"^\d{10,15}$")
            .WithMessage("Phone number must be a valid phone number")
            .Length(4,15);
    }
}
