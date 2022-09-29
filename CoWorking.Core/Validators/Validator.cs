using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.Roles;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Core.Validators
{
    public static class Validator
    {
        public static async Task<bool> IsUserEmailUnique(UserManager<User> manager, string email)
        {
            return await manager.FindByEmailAsync(email) == null;
        }

        public static async Task<bool> IsUniqueUserName(UserManager<User> manager, string username)
        {
            return await manager.FindByNameAsync(username) != null;
        }

        public static async Task<bool> IsSystemRoleAndNoAdmin(RoleManager<IdentityRole> manager, string role)
        {
            return role == Authorization.Roles.Admin.ToString() ||
                await manager.FindByNameAsync(role) == null;
        }
    }
}
