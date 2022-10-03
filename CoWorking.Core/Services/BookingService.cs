using AutoMapper;
using CoWorking.Contracts.Data;
using CoWorking.Contracts.Data.Entities.BookingEntity;
using CoWorking.Contracts.Data.Query;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.DTO.CommentDTO;
using CoWorking.Contracts.Exceptions;
using CoWorking.Contracts.Services;
using Microsoft.EntityFrameworkCore;

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
            var bookings = _bookingRepository.Query().Select(x => new BookingDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                DateStart = x.DateStart,
                DateEnd = x.DateEnd,
                Reserved = x.DeveloperId != null
            })
            .ToList();

            return await Task.FromResult(bookings);
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

        public async Task<BookingInfoDTO> GetBookingByIdWithUserAsync(int id)
        {
            var includes = new Includes<Booking>(query =>
            {
                return query.Include(x => x.Developer).Include(x => x.Comments).ThenInclude(x => x.User);
            });

            var booking = await _bookingRepository.GetByKeyWithIncludesAsync(x => x.Id == id, includes.Expression);

            var bookingDTO = new BookingInfoDTO();
            _mapper.Map(booking, bookingDTO);

            if(booking.Developer != null)
            {
                var userBookingDTO = new UserBookingInfoDTO();
                _mapper.Map(booking, userBookingDTO);

                bookingDTO.User = userBookingDTO;
            }

            if(booking.Comments.Count > 0)
            {
                var commentsDTO = new List<CommentInfoDTO>();
                _mapper.Map(booking.Comments, commentsDTO);

                bookingDTO.Comments = commentsDTO;
            }

            return await Task.FromResult(bookingDTO);
        }

        public async Task<IEnumerable<ReservedBookingDTO>> GetReservedBookingList()
        {
            var bookings = _bookingRepository.Query()
                .Where(x => x.DeveloperId != null)
                .Select(x => new ReservedBookingDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    DateStart = x.DateStart,
                    DateEnd = x.DateEnd,
                }).ToList();

            return await Task.FromResult(bookings);
        }

        public async Task<IEnumerable<UnReservedBookingDTO>> GetUnReservedBookingList()
        {
            var bookings = _bookingRepository.Query()
                .Where(x => x.DeveloperId == null)
                .Select(x => new UnReservedBookingDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    CommentsCount = x.Comments.Count
                }).ToList();

            return await Task.FromResult(bookings);
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
