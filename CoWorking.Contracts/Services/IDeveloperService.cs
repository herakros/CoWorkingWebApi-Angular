using CoWorking.Contracts.DTO.DeveloperDTO;

namespace CoWorking.Contracts.Services
{
    public interface IDeveloperService
    {
        Task<UserReservationDTO> IsUserHasReservation(UserIdDTO model); 
    }
}
