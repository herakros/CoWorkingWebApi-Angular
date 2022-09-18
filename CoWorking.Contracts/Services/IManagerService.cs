using CoWorking.Contracts.DTO.ManagerDTO;

namespace CoWorking.Contracts.Services
{
    public interface IManagerService
    {
        Task SubscribeUserToBookingAsync(SubscribeUserDTO model);
    }
}
