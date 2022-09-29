using CoWorking.Contracts.DTO.DeveloperDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class UserBookingIdValidation : AbstractValidator<UsedBookingIdDTO>
    {
        public UserBookingIdValidation()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.BookingId).NotNull();
        }
    }
}
