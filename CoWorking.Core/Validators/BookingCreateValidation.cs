using CoWorking.Contracts.DTO.BookingDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class BookingCreateValidation : AbstractValidator<CreateBookingDTO>
    {
        public BookingCreateValidation()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(5, 50);

            RuleFor(x => x.Description)
                .NotNull()
                .Length(5, 300);
        }
    }
}
