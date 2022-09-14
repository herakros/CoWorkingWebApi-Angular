using CoWorking.Contracts.DTO.BookingDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class BookingInfoValidation : AbstractValidator<BookingInfoDTO>
    {
        public BookingInfoValidation()
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
