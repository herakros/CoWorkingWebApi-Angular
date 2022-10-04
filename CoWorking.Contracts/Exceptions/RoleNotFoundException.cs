namespace CoWorking.Contracts.Exceptions
{
    public class RoleNotFoundException : NotFoundException
    {
        public RoleNotFoundException() : base("System don't have this role!") { }
    }
}
