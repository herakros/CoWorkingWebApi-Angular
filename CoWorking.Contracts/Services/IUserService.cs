using CoWorking.Contracts.DTO.UserDTO;

namespace CoWorking.Contracts.Services
{
    public interface IUserService
    {
        Task<UserProfileDTO> GetUserInfo(string userId);

        Task EditUserInfo(UserEditPersonalInfoDTO model, string userId);

        Task EditUserPassword(UserEditPasswordDTO model, string userId);
    }
}
