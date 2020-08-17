using System.Threading.Tasks;
using Chase.Entities.Tangible;
using Microsoft.AspNetCore.Identity;

namespace Chase.UI.Identity
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole {Name = "Admin"});
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole {Name = "Member"});
            }
            
        }
    }
}