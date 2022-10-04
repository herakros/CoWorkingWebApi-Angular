namespace CoWorking.Contracts.Exceptions
{
    public class BookingIsReservedException : BadRequestException
    {
        public BookingIsReservedException() : base("This Booking already reserved!") { }
    }
}
