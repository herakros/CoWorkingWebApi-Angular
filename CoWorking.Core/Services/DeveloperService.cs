using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.DTO.DeveloperDTO;
using CoWorking.Contracts.Services;

namespace CoWorking.Core.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IRepository<Booking> _bookingRepository;
        public DeveloperService(IRepository<Booking> bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<UserReservationDTO> IsUserHasReservation(UserIdDTO model)
        {
            var specification = new Bookings.IsBookingHasUser(model.Id);
            var booking = await _bookingRepository.GetFirstBySpecAsync(specification);

            var userReservation = new UserReservationDTO();

            if (booking != null)
            {
                userReservation.IsReservation = true;
                userReservation.BookingId = booking.Id;
            }

            return userReservation;
        }
    }
}
