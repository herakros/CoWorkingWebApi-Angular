namespace CoWorking.Contracts.Exceptions
{
    public class UserAlreadyHasReservationException : BadRequestException
    {
        public UserAlreadyHasReservationException() : base("This User already has reservation!") { }
    }
}
