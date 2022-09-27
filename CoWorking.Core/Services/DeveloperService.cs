using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.DeveloperDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Core.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IRepository<Booking> _bookingRepository;
        private readonly UserManager<User> _userManager;
        public DeveloperService(IRepository<Booking> bookingRepository,
            UserManager<User> userManager)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }

        public async Task ChangeBookingDateAsync(ChangeBookingDateDTO model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "User not found!");
            }

            var booking = await _bookingRepository.GetByKeyAsync(model.BookingId);

            if (booking == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "Booking not found!");
            }

            if (model.DateOfEnd <= DateTime.Today)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "The date cannot be less than today!");
            }

            booking.DateEnd = model.DateOfEnd;

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task<bool> IsItUserBookingAsync(UsedBookingIdDTO model)
        {
            var specification = new Bookings.IsItUserBooking(model);
            var booking = await _bookingRepository.GetFirstBySpecAsync(specification);

            return booking != null;
        }

        public async Task<UserReservationDTO> IsUserHasReservationAsync(UserIdDTO model)
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
