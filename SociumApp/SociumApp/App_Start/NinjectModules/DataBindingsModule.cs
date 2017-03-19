using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.App_Start.NinjectModules
{
    public class DataBindingsModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<EfSociumDbContext>().ToSelf().InRequestScope();
            this.Kernel.Bind<IEfSociumDbContext>().To<EfSociumDbContext>();
            this.Kernel.Bind<IEfSociumDataProvider>().To<EfSociumDataProvider>().InRequestScope();
        }
    }
}