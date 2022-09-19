namespace CoWorking.Contracts.Roles
{
    public class Authorization
    {
        // 1 enum = 1 file
        public enum Roles : int
        {
            Admin = 1,
            Manager = 2,
            Developer = 3
        }
    }
}
