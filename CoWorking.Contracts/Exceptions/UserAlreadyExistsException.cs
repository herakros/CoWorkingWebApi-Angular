namespace CoWorking.Contracts.Exceptions
{
    public class UserAlreadyExistsException : BadRequestException
    {
        public UserAlreadyExistsException(string value) : base($"User with this {value} was already exists!") { }
    }
}
