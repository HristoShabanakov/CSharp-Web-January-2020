using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lekarna.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Lekarna.SeedData
{
    public class ApplicationDbContextSeeder
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public ApplicationDbContextSeeder(IServiceProvider serviceProvider, ApplicationDbContext dbContext)
        {
            this.userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            this.roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();
            this.dbContext = dbContext;
        }

        public async Task SeedDataAsync()
        {
            await SeedUsersAsync();
            await SeedRolesAsync();
            await SeedUserToRolesAsync();
        }

        private async Task SeedUserToRolesAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");
            var user = await userManager.FindByNameAsync("John");

            var exists = dbContext.UserRoles.Any(x => x.UserId == user.Id && x.RoleId == role.Id);

            if (exists)
            {
                return;
            }

            dbContext.UserRoles.Add(new IdentityUserRole<string>
            {
                RoleId = role.Id,
                UserId = user.Id
            });

           await dbContext.SaveChangesAsync();
        }

        private async Task SeedRolesAsync()
        {
            var role = await roleManager.FindByNameAsync("Admin");

            if (role != null)
            {
                return;
            }

            await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
        }

        private async Task SeedUsersAsync()
        {
            var user = await userManager.FindByNameAsync("John");

            if(user != null)
            {
                return;
            }

            await userManager.CreateAsync(new IdentityUser
            {
                UserName = "John",
                Email = "John@doe.com",
                EmailConfirmed = true
            },
            "test123") ;
        }
    }
}
