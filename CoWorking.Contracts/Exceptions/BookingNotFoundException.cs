namespace CoWorking.Contracts.Exceptions
{
    public class BookingNotFoundException : NotFoundException
    {
        public BookingNotFoundException() : base("Booking not found!") { }
    }
}
