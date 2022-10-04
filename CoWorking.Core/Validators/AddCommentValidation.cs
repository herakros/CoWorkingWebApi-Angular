using CoWorking.Contracts.DTO.CommentDTO;
using FluentValidation;

namespace CoWorking.Core.Validators
{
    public class AddCommentValidation : AbstractValidator<AddCommentDTO>
    {
        public AddCommentValidation()
        {
            RuleFor(x => x.BookingId).NotNull();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Text).NotNull();
        }
    }
}
