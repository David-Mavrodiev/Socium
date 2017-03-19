using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string OwnerUsername { get; set; }

        public string Title { get; set; }

        public List<OptionViewModel> Options { get; set; }
    }
}