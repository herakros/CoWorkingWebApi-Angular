using CoWorking.Contracts.DTO.UserDTO;

namespace CoWorking.Contracts.Services
{
    public interface IUserService
    {
        Task<UserProfileDTO> GetUserInfo(string userId);
    }
}
