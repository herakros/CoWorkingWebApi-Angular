using CoWorking.Contracts.DTO.UserDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserLoginValidation : AbstractValidator<UserLoginDTO>
    {
        public UserLoginValidation()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(user => user.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}
