namespace CoWorking.Contracts.DTO.BookingDTO
{
    public class BookingInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset? DateStart { get; set; }

        public DateTimeOffset? DateEnd { get; set; }

        public bool Reserved { get; set; }
    }
}
