using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Models
{
    public class Question : IEfModel
    {
        public Question()
        {
            this.Options = new HashSet<Option>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Option> Options { get; set; }
    }
}
