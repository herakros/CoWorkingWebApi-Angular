using CoWorking.Contracts.DTO.UserDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserEditPersonalInfoValidation : AbstractValidator<UserEditPersonalInfoDTO>
    {
        public UserEditPersonalInfoValidation()
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
        }
    }
}
