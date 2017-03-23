using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SociumApp.AppStart.Startup))]
namespace SociumApp.AppStart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
