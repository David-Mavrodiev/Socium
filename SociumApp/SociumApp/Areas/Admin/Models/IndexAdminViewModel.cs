using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.Areas.Admin.Models
{
    public class IndexAdminViewModel
    {
        public int QuestionsCount { get; set; }

        public int OptionsCount { get; set; }

        public int VotesCount { get; set; }

        public int UsersCount { get; set; }
    }
}