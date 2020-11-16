using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreTodo
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

            await EnsureTestAdminAsync(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Checks to see if an Administrator role exists in the database
            var alreadyExists = await roleManager
                .RoleExistsAsync(Constants.AdministratorRole);

            System.Diagnostics.Debug.WriteLine($"\n\n ===========> Administrator role exists ? {alreadyExists} <============== \n\n");

            if(alreadyExists) return;
            // If not, it creates one
            await roleManager.CreateAsync(new IdentityRole(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(UserManager<IdentityUser> userManager)
        {
            // Check to see if an administrator exists in the database
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == "admin@todo.local")
                .SingleOrDefaultAsync();
            // If yes, return
            if(testAdmin != null) return;
            // Creates an administrator user
            testAdmin = new IdentityUser {
                UserName = "admin@todo.local",
                Email = "admin@todo.local"
            };

            await userManager.CreateAsync(testAdmin, "NotSecure123!!");
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }
    }
}