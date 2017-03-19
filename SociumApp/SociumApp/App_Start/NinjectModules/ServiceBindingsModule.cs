using Ninject.Modules;
using Ninject.Web.Common;
using SociumApp.Services;
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
            this.Kernel.Bind<QuestionService>().ToSelf().InRequestScope();
            this.Kernel.Bind<UserService>().ToSelf().InRequestScope();
        }
    }
}