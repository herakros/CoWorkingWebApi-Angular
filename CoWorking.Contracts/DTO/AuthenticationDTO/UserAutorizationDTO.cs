namespace CoWorking.Contracts.DTO.AuthenticationDTO
{
    public class UserAutorizationDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Provider { get; set; }
    }
}
