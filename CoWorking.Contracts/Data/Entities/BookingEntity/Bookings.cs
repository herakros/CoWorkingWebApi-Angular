using Ardalis.Specification;
using CoWorking.Contracts.DTO.BookingDTO;
using CoWorking.Contracts.DTO.DeveloperDTO;
using CoWorking.Contracts.DTO.UserDTO;

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
                        Name = x.Name,
                        CommentsCount = x.Comments.Count
                    })
                    .Include(x => x.Comments)
                    .Where(x => x.DeveloperId == null);
            }
        } 

        public class BookingWithUserAndComments : Specification<Booking>
        {
            public BookingWithUserAndComments(int id)
            {
                Query
                    .Include(x => x.Developer)
                    .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                    .Where(x => x.Id == id);
            }
        }

        public class IsBookingHasUser : Specification<Booking>
        {
            public IsBookingHasUser(string userId)
            {
                Query
                    .Where(x => x.DeveloperId == userId);
            }
        }

        public class IsItUserBooking: Specification<Booking>
        {
            public IsItUserBooking(UsedBookingIdDTO usedBookingId)
            {
                Query
                    .Where(x => x.DeveloperId == usedBookingId.UserId &&
                    x.Id == usedBookingId.BookingId);
            }
        }
    }
}
