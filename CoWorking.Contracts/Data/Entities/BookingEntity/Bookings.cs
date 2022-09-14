using Ardalis.Specification;
using CoWorking.Contracts.DTO.BookingDTO;

namespace CoWorking.Contracts.Data.Entities.BookingEntity
{
    public class Bookings
    {
        public class BookingInfoList : Specification<Booking, BookingInfoDTO>
        {
            public BookingInfoList()
            {
                Query
                    .Select(x => new BookingInfoDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        DateStart = x.DateStart,
                        DateEnd = x.DateEnd,
                        Reserved = x.DeveloperId != null
                    });
            }
        } 
    }
}
