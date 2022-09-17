using CoWorking.Contracts.DTO.BookingDTO;

namespace CoWorking.Contracts.Services
{
    public interface IBookingService
    {
        Task AddBookingAsync(CreateBookingDTO model);

        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();

        Task DeleteBookingAsync(int id);

        Task PutBookingAsync(BookingDTO model);

        Task<BookingDTO> GetBookingByIdAsync(int id);

        Task<BookingInfoDTO> GetBookingByIdWithUserAsync(int id);

        Task<IEnumerable<UnReservedBookingDTO>> GetUnReservedBookingList();

        Task<IEnumerable<ReservedBookingDTO>> GetReservedBookingList();
    }
}
