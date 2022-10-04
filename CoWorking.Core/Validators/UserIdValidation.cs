using CoWorking.Contracts.DTO.DeveloperDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserIdValidation : AbstractValidator<UserIdDTO>
    {
        public UserIdValidation()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }
}
