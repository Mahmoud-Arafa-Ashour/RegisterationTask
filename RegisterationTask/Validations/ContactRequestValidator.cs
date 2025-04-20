namespace RegisterationTask.Validations
{
    public class ContactRequestValidator : AbstractValidator<ContactRequest>
    {
        public ContactRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MinimumLength(2)
                .WithMessage("First name must be at least 2 characters long")
                .MaximumLength(150)
                .WithMessage("First name must not exceed 150 characters");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MinimumLength(2)
                .WithMessage("Last name must be at least 2 characters long")
                .MaximumLength(150)
                .WithMessage("Last name must not exceed 150 characters");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email must be a valid email address");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .Matches(@"^\d+$")
                .WithMessage("Phone number must be a valid phone number")
                .Length(4, 15);
            RuleFor(x => x.BirthDay)
                .NotEmpty()
                .WithMessage("Birth date is required");
        }
    }
}
