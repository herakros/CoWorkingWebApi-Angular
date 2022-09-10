using CoWorking.Contracts.Data.Entities.CommentEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;

namespace CoWorking.Contracts.Data.Entities.BookingEntity
{
    public class Booking : IBaseEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset DateStart { get; set; }

        public DateTimeOffset DateEnd { get; set; }

        public string DeveloperId { get; set; }

        public User Developer { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
