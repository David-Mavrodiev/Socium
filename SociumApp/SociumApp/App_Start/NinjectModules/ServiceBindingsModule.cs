using Ninject.Modules;
using Ninject.Web.Common;
using SociumApp.Services;
using SociumApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.App_Start.NinjectModules
{
    public class ServiceBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IQuestionService>().To<QuestionService>();
            this.Kernel.Bind<QuestionService>().ToSelf().InRequestScope();
            this.Kernel.Bind<IUserService>().To<UserService>();
            this.Kernel.Bind<UserService>().ToSelf().InRequestScope();
            this.Kernel.Bind<IAdminService>().To<AdminService>();
            this.Kernel.Bind<AdminService>().ToSelf().InRequestScope();
            this.Kernel.Bind<IChatService>().To<ChatService>();
            this.Kernel.Bind<ChatService>().ToSelf().InRequestScope();
        }
    }
}