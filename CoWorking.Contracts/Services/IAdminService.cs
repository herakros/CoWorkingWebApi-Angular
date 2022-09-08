using CoWorking.Contracts.DTO.AdminPanelDTO;

namespace CoWorking.Contracts.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<UserInfoDTO>> GetAllUsersAsync();
    }
}
