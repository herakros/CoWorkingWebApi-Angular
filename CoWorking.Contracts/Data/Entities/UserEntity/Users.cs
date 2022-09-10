using Ardalis.Specification;
using CoWorking.Contracts.DTO.AdminPanelDTO;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Contracts.Data.Entities.UserEntity
{
    public class Users
    {
        public class UsersWithRole : Specification<User, UserInfoDTO>
        {
            public UsersWithRole(UserManager<User> manager)
            {
                Query
                    .Select(x => new UserInfoDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Surname = x.Surname,
                        UserName = x.UserName,
                        Email = x.Email,
                        Role = manager.GetRolesAsync(x).Result[0]
                    });
            }
        }
    }
}
