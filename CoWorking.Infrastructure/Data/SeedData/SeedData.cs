using CoWorking.Contracts.Data.Entities.UserEntity;
using CoWorking.Contracts.Roles;
using Microsoft.AspNetCore.Identity;

namespace CoWorking.Infrastructure.Data.SeedData
{
    public static class SeedData
    {
        public static async Task SystemRoles(UserManager<User> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Authorization.Roles.Developer.ToString()));

            var admin = new User
            {
                Name = "First",
                Surname = "Last",
                UserName = "Admin",
                Email = "secret@mail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            if(userManager.Users.All(u => u.Id != admin.Id))
            {
                await userManager.CreateAsync(admin, "Password1!");
                await userManager.AddToRoleAsync(admin, Authorization.Roles.Admin.ToString());
            }
        }
    }
}
