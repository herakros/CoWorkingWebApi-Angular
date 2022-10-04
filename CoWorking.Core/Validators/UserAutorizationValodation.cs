using CoWorking.Contracts.DTO.AuthenticationDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserAutorizationValodation : AbstractValidator<UserAutorizationDTO>
    {
        public UserAutorizationValodation()
        {
            RuleFor(x => x.Token).NotNull();
            RuleFor(x => x.RefreshToken).NotNull();
            RuleFor(x => x.IsAuthenticated).NotNull();
        }
    }
}
