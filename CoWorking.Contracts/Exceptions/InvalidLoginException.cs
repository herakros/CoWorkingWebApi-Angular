namespace CoWorking.Contracts.Exceptions
{
    public class InvalidLoginException : UnauthorizedException
    {
        public InvalidLoginException() : base("Incorrect Email or Password!") { }
    }
}
