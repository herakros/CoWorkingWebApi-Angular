using CoWorking.Contracts.DTO.CommentDTO;

namespace CoWorking.Contracts.Services
{
    public interface ICommentService
    {
        Task AddCommentAsync(AddCommentDTO model);
    }
}
