namespace CoWorking.Contracts.Exceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException() : base("User not Found!") { }
    }
}
