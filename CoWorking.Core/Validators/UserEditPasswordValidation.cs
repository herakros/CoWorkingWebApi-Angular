using CoWorking.Contracts.DTO.UserDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserEditPasswordValidation : AbstractValidator<UserEditPasswordDTO>
    {
        public UserEditPasswordValidation()
        {
            RuleFor(user => user.CurrentPassword)
               .NotEmpty()
               .MinimumLength(8)
               .Matches("[A-Z]").WithMessage("{PropertyName} must contain one or more capital letters.")
               .Matches("[a-z]").WithMessage("{PropertyName} must contain one or more lowercase letters.")
               .Matches(@"\d").WithMessage("{PropertyName} must contain one or more digits.")
               .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]").WithMessage("{PropertyName} must contain one or more special characters.")
               .Matches("^[^£# “”]*$").WithMessage("{PropertyName} must not contain the following characters £ # “” or spaces.");

            RuleFor(user => user.ChangedPassword)
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
