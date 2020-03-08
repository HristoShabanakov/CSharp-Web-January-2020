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
            throw new NotImplementedException();
        }

        private async Task SeedRolesAsync()
        {
            throw new NotImplementedException();
        }

        private async Task SeedUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
