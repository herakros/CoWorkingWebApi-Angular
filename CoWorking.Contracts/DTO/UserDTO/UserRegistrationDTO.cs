using CoWorking.Contracts.Roles;

namespace CoWorking.Contracts.DTO.UserDTO
{
    public class UserRegistrationDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AuthorizationRoles Role { get; set; }
        public string Password { get; set; }
    }
}
