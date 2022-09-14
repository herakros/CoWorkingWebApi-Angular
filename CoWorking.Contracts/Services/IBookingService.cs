using CoWorking.Contracts.DTO.BookingDTO;

namespace CoWorking.Contracts.Services
{
    public interface IBookingService
    {
        Task AddBookingAsync(CreateBookingDTO model);

        Task<IEnumerable<BookingInfoDTO>> GetAllBookingsAsync();

        Task DeleteBookingAsync(int id);

        Task PutBookingAsync(BookingInfoDTO model);

        Task<BookingInfoDTO> GetBookingByIdAsync(int id);
    }
}
