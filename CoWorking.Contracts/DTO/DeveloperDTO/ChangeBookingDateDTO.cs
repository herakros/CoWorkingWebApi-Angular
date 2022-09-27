namespace CoWorking.Contracts.DTO.DeveloperDTO
{
    public class ChangeBookingDateDTO
    {
        public int BookingId { get; set; }
        public string UserId { get; set; }
        public DateTime DateOfEnd { get; set; }
    }
}
