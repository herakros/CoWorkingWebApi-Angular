using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.AuthenticationDTO;

namespace CoWorking.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task RegistrationAsync(User user, string password, string roleName);
        Task<UserAutorizationDTO> LoginAsync(string email, string password);
        Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO);
        Task LogoutAsync(UserAutorizationDTO userTokensDTO);
    }
}
