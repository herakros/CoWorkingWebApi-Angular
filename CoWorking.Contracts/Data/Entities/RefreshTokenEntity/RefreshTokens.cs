using Ardalis.Specification;

namespace CoWorking.Contracts.Data.Entities.RefreshTokenEntity
{
    public class RefreshTokens
    {
        public class SearchRefreshToken : Specification<RefreshToken>
        {
            public SearchRefreshToken(string refreshToken)
            {
                Query
                    .Where(x => x.Token == refreshToken);
            }
        }
    }
}
