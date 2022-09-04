namespace CoWorking.Contracts.DTO.AuthenticationDTO
{
    public class UserAutorizationDTO
    {
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
