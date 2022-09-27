using CoWorking.Contracts.DTO.DeveloperDTO;

namespace CoWorking.Contracts.Services
{
    public interface IDeveloperService
    {
        Task<UserReservationDTO> IsUserHasReservationAsync(UserIdDTO model); 

        Task<bool> IsItUserBookingAsync(UsedBookingIdDTO model);

        Task ChangeBookingDateAsync(ChangeBookingDateDTO model);
    }
}
