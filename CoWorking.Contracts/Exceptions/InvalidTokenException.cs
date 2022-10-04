namespace CoWorking.Contracts.Exceptions
{
    public class InvalidTokenException : BadRequestException
    {
        public InvalidTokenException() : base("Invalid Token") { }
    }
}
