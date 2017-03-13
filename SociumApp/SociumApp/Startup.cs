using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SociumApp.Startup))]
namespace SociumApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
