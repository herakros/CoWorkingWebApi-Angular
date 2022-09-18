namespace CoWorking.Contracts.DTO.ManagerDTO
{
    public class SubscribeUserDTO
    {
        public string UserName { get; set; }

        public int BookingId { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }
    }
}
