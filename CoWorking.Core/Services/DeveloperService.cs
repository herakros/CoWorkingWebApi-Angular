﻿using CoWorking.Contracts.Data;
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
                throw new UserNotFoundException();
            }

            var booking = await _bookingRepository.GetByKeyAsync(model.BookingId);

            if (booking == null)
            {
                throw new BookingNotFoundException();
            }

            booking.DateEnd = model.DateOfEnd;

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public Task<bool> IsItUserBookingAsync(UsedBookingIdDTO model)
        {
            var booking = _bookingRepository.Query()
                .Where(x => x.DeveloperId == model.UserId && x.Id == model.BookingId)
                .FirstOrDefault();

            return Task.FromResult(booking != null);
        }

        public Task<UserReservationDTO> IsUserHasReservationAsync(UserIdDTO model)
        {
            var booking = _bookingRepository.Query()
                .FirstOrDefault(x => x.DeveloperId == model.Id);

            var userReservation = new UserReservationDTO();

            if (booking != null)
            {
                userReservation.IsReservation = true;
                userReservation.BookingId = booking.Id;
            }

            return Task.FromResult(userReservation);
        }
    }
}
