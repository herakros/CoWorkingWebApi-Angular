using CoWorking.Contracts.DTO.UserDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserRegistrationValidation : AbstractValidator<UserRegistrationDTO>
    {
        public UserRegistrationValidation()
        {
            RuleFor(user => user.Name)
               .NotNull()
               .Length(3, 50);

            RuleFor(user => user.Surname)
                .NotNull()
                .Length(3, 50);

            RuleFor(user => user.UserName)
                .NotNull()
                .Length(3, 50);

            RuleFor(user => user.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(user => user.Role)
                .NotNull()
                .IsInEnum();

            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("{PropertyName} must contain one or more capital letters.")
                .Matches("[a-z]").WithMessage("{PropertyName} must contain one or more lowercase letters.")
                .Matches(@"\d").WithMessage("{PropertyName} must contain one or more digits.")
                .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("{PropertyName} must contain one or more special characters.")
                .Matches("^[^£# “”]*$").WithMessage("{PropertyName} must not contain the following characters £ # “” or spaces.");
        }
    }
}
