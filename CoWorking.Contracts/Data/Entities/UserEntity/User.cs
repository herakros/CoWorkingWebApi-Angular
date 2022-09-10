using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.CommentEntity;
using CoWorking.Contracts.Data.Entities.RefreshTokenEntity;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Contracts.Data.Entities.UserEntity
{
    public class User : IdentityUser, IBaseEntity
    {
        public string Name { get;set; }
        public string Surname { get; set; } 
        public Booking Booking { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
