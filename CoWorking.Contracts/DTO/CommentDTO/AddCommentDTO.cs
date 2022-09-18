namespace CoWorking.Contracts.DTO.CommentDTO
{
    public class AddCommentDTO
    {
        public int BookingId { get; set; }

        public string UserId { get; set; }

        public string Text { get; set; }
    }
}
