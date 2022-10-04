using CoWorking.Contracts.DTO.ManagerDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class SubscribeUserValidation : AbstractValidator<SubscribeUserDTO>
    {
        public SubscribeUserValidation()
        {
            RuleFor(x => x.DateStart < DateTime.Today)
                .NotNull()
                .WithMessage("The date cannot be less than today!");

            RuleFor(x => x.DateEnd <= DateTime.Today && x.DateEnd <= x.DateStart)
                .NotNull()
                .WithMessage("Date of end cannot be less or equal of date start!");

            RuleFor(x => x.UserName)
                .NotNull();

            RuleFor(x => x.BookingId)
                .NotNull();
        }
    }
}
