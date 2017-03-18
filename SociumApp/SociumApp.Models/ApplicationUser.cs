using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Models
{
    public class ApplicationUser : IdentityUser, IEfModel
    {
        public ApplicationUser()
        {
            this.MyVotes = new HashSet<Vote>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public virtual ICollection<Vote> MyVotes { get; set; }
    }
}
