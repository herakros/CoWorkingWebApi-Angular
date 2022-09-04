using CoWorking.Contracts.DTO.AuthenticationDTO;
using CoWorking.Contracts.DTO.UserDTO;

namespace CoWorking.Contracts.Services
{
    public interface IAuthenticationService
    {
        Task RegistrationAsync(UserRegistrationDTO model);
        Task<UserAutorizationDTO> LoginAsync(UserLoginDTO model);
        Task<UserAutorizationDTO> RefreshTokenAsync(UserAutorizationDTO userTokensDTO);
        Task LogoutAsync(UserAutorizationDTO userTokensDTO);
    }
}
