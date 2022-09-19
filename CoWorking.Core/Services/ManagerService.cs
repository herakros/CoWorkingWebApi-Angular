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
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly UserManager<User> _userManager;
        public ManagerService(IMapper mapper,
            IRepository<User> userRepository,
            UserManager<User> userManager,
            IRepository<Booking> bookingRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        public async Task SubscribeUserToBookingAsync(SubscribeUserDTO model)
        {
            // You have added fluent validation but didn't use it
            if(model.DateStart < DateTime.Today)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "The date cannot be less than today!");
            }

            if(model.DateEnd <= DateTime.Today && model.DateEnd <= model.DateStart)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "Date of end cannot be less or equal of date start!");
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

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

            if(booking.Developer != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "This Booking already reserved!");
            }

            var specification = new Bookings.IsBookingHasUser(user.Id);
            var userBooking = await _bookingRepository.GetFirstBySpecAsync(specification);

            if(userBooking != null)
            {
                throw new HttpException(System.Net.HttpStatusCode.BadRequest,
                    "This User already has reservation!");
            }

            _mapper.Map(model, booking);
            booking.Developer = user;

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }
    }
}
