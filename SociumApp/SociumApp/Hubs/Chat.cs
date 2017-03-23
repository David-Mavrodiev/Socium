using Microsoft.AspNet.SignalR;
using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.Hubs
{
    public class Chat : Hub
    {
        //TODO: Abstract this dependencies
        static IEfSociumDbContext context = new EfSociumDbContext();
        static IEfSociumDataProvider provider = new EfSociumDataProvider(context);
        public ChatService Service = new ChatService(provider);

        public void SendMessage(string msg)
        {
            string answer = this.Service.FindAnswerByQuestion(msg);
            Clients.Caller.addMessage(answer);
        }
    }
}