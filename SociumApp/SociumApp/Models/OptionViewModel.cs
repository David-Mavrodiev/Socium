using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.Models
{
    public class OptionViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int VotesCount { get; set; }

        public Question Question { get; set; }

        public Option Option { get; set; }
    }
}