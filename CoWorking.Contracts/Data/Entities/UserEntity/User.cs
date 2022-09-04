using CoWorking.Contracts.Data.Entities.RefreshTokenEntity;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Contracts.Data.Entities.UserEntity
{
    public class User : IdentityUser, IBaseEntity
    {
        public string Name { get;set; }
        public string Surname { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
