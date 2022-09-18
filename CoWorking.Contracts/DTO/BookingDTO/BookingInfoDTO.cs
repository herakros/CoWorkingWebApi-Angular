using CoWorking.Contracts.Data.Entities.CommentEntity;
using CoWorking.Contracts.DTO.CommentDTO;

namespace CoWorking.Contracts.DTO.BookingDTO
{
    public class BookingInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public List<CommentInfoDTO> Comments { get; set; }

        public UserBookingInfoDTO User { get; set; }
    }
}
