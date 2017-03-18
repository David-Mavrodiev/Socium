using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Models
{
    public class Vote : IEfModel
    {
        public Vote()
        {
            this.LikedUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        public ApplicationUser Owner { get; set; }

        public virtual ICollection<ApplicationUser> LikedUsers { get; set; }
    }
}
