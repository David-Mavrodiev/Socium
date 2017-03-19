using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.Areas.Profile.Models
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public List<Question> MyQuestions { get; set; }

        public List<Vote> MyVotes { get; set; }
    }
}