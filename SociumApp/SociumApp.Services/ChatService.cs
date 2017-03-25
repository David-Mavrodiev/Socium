using SociumApp.Data.Contracts;
using SociumApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services
{
    public class ChatService : IChatService
    {
        private const string defaultText = "Нямам отговор на въпроса. Направи анкета! :-)";
        private IEfSociumDataProvider provider;

        public ChatService(IEfSociumDataProvider provider)
        {
            this.provider = provider;
        }

        public string FindAnswerByQuestion(string userQuestion)
        {
            int bestPartsCount = 0;
            string answer = defaultText;
            string[] userContent = userQuestion.Split(new char[] { ' ', '?' });

            foreach (var question in this.provider.Questions.GetAll().ToList())
            {
                string[] content = question.Title.Split(new char[] { ' ', '?' });
                int countOfSameParts = 0;

                for (int i = 0; i < content.Length; i++)
                {
                    for (int j = 0; j < userContent.Length; j++)
                    {
                        if (content[i].ToLower() == userContent[j].ToLower())
                        {
                            countOfSameParts++;
                            break;
                        }
                    }
                }

                if (countOfSameParts > bestPartsCount)
                {
                    bestPartsCount = countOfSameParts;
                    answer = question.Options.OrderByDescending(q => q.Votes.Count).ToList()[0].Description;
                }
            }

            return answer;
        }

        public IEfSociumDataProvider GetProvider
        {
            get
            {
                return this.provider;
            }
        }
    }
}
