using CoWorking.Contracts.DTO.DeveloperDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class ChangeBookingDateValidation : AbstractValidator<ChangeBookingDateDTO>
    {
        public ChangeBookingDateValidation()
        {
            RuleFor(x => x.DateOfEnd <= DateTime.Today)
                .NotEmpty()
                .WithMessage("The date cannot be less than today!");

            RuleFor(x => x.UserId)
                .NotNull();

            RuleFor(x => x.BookingId)
                .NotNull();
        }
    }
}
