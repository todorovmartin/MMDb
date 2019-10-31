using Microsoft.AspNetCore.Identity;
using MMDb.Data;
using MMDb.Data.Models;
using MMDb.Web.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMDb.Web.Services
{
    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public UsersService(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return this.userManager.FindByNameAsync(username).GetAwaiter().GetResult();
        }
    }
}
