using CoWorking.Contracts.DTO.AdminPanelDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserInfoValidation : AbstractValidator<UserInfoDTO>
    {
        public UserInfoValidation()
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
                .NotNull();
        }
    }
}
