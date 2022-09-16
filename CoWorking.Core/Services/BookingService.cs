using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;

namespace CoWorking.Core.Services
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Booking> _bookingRepository;
        public BookingService(IMapper mapper, 
            IRepository<Booking> bookingRepository)
        {
            _mapper = mapper;
            _bookingRepository = bookingRepository;
        }

        public async Task AddBookingAsync(CreateBookingDTO model)
        {
            var booking = new Booking();
            _mapper.Map(model, booking);

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByKeyAsync(id);

            if (booking == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "Booking not found!");
            }

            await _bookingRepository.DeleteAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            var specification = new Bookings.BookingList();
            var bookings = await _bookingRepository.GetListBySpecAsync(specification);

            return bookings;
        }       

        public async Task<BookingDTO> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByKeyAsync(id);
            if (booking == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "Booking not found!");
            }

            var bookingDTO = new BookingDTO();
            _mapper.Map(booking, bookingDTO);

            return bookingDTO;
        }

        public async Task<BookingDTO> GetBookingByIdWithUserAsync(int id)
        {
            var specification = new Bookings.BookingWithUserAndComments(id);
            var booking = await _bookingRepository.GetFirstBySpecAsync(specification);
            return null;
        }

        public Task<IEnumerable<ReservedBookingDTO>> GetReservedBookingList()
        {
            var specification = new Bookings.ReservedBookingList();
            var bookings = _bookingRepository.GetListBySpecAsync(specification);

            return bookings;
        }

        public Task<IEnumerable<UnReservedBookingDTO>> GetUnReservedBookingList()
        {
            var specification = new Bookings.UnReservedBookingList();
            var bookings = _bookingRepository.GetListBySpecAsync(specification);

            return bookings;
        }

        public async Task PutBookingAsync(BookingDTO model)
        {
            var booking = await _bookingRepository.GetByKeyAsync(model.Id);

            if (booking == null)
            {
                throw new HttpException(System.Net.HttpStatusCode.NotFound,
                    "Booking not found!");
            }

            _mapper.Map(model, booking);

            await _bookingRepository.UpdateAsync(booking);
            await _bookingRepository.SaveChangesAsync();
        }
    }
}
