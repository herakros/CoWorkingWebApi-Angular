using Ardalis.Specification;
using CoWorking.Contracts.DTO.BookingDTO;

namespace CoWorking.Contracts.Data.Entities.BookingEntity
{
    public class Bookings
    {
        public class BookingList : Specification<Booking, BookingDTO>
        {
            public BookingList()
            {
                Query
                    .Select(x => new BookingDTO
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

        public class ReservedBookingList : Specification<Booking, ReservedBookingDTO>
        {
            public ReservedBookingList()
            {
                Query
                    .Select(x => new ReservedBookingDTO
                    {
                        Id = x.Id,
                        Name = x.Name,
                        DateStart = x.DateStart,
                        DateEnd = x.DateEnd,
                    })
                    .Where(x => x.DeveloperId != null);
            }
        }

        public class UnReservedBookingList : Specification<Booking, UnReservedBookingDTO>
        {
            public UnReservedBookingList()
            {
                Query
                    .Select(x => new UnReservedBookingDTO
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .Where(x => x.DeveloperId == null);
            }
        }
    }
}
