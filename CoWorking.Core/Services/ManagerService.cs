using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.DTO.ManagerDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Core.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly UserManager<User> _userManager;
        public ManagerService(IMapper mapper,
            UserManager<User> userManager,
            IRepository<Booking> bookingRepository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        public async Task SubscribeUserToBookingAsync(SubscribeUserDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var booking = await _bookingRepository.GetByKeyAsync(model.BookingId);

            if (booking == null)
            {
                throw new BookingNotFoundException();
            }

            if(booking.Developer != null)
            {
                throw new BookingIsReservedException();
            }

            var userBooking = _bookingRepository.Query()
                .FirstOrDefault(x => x.DeveloperId == user.Id);

            if(userBooking != null)
            {
                throw new UserAlreadyHasReservationException();
            }

            _mapper.Map(model, booking);
            booking.Developer = user;

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }
    }
}
