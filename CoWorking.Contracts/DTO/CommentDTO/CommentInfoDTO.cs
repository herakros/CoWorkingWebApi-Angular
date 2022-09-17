namespace CoWorking.Contracts.DTO.CommentDTO
{
    public class CommentInfoDTO
    {
        public string Text { get; set; }

        public DateTimeOffset DateOfCreate { get; set; }

        public UserCommentDTO User { get; set; }
    }
}
