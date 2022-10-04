namespace CoWorking.Contracts.Exceptions
{
    public class UserAlreadyExistsException : BadRequestException
    {
        public UserAlreadyExistsException(string valeu) : base($"User with this {valeu} was already exists!") { }
    }
}
