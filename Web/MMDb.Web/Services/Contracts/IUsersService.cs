using MMDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMDb.Web.Services.Contracts
{
    public interface IUsersService
    {
        ApplicationUser GetUserByUsername(string username);
    }
}
