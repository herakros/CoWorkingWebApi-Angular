namespace CoWorking.Contracts.DTO.BookingDTO
{
    public class ReservedBookingDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
