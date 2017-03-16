using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Identity.Contracts
{
    public interface IApplicationSignInManager
    {
        Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user);
    }
}
