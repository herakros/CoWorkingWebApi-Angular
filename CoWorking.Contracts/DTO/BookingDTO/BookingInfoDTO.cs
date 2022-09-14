namespace CoWorking.Contracts.DTO.BookingDTO
{
    public class BookingInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public bool Reserved { get; set; }
    }
}
