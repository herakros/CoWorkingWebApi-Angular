using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;

namespace CoWorking.Contracts.Data.Entities.CommentEntity
{
    public class Comment : IBaseEntity
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTimeOffset DateOfCreate { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
