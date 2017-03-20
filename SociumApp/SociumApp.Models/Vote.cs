using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Models
{
    public class Vote : IEfModel
    {
        public Vote()
        {
        }

        [Key]
        public int Id { get; set; }

        public string OwnerId { get; set; }

        public int QuestionId { get; set; }

        public int OptionId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual ApplicationUser Owner { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        [ForeignKey("OptionId")]
        public virtual Option Option { get; set; }
    }
}
