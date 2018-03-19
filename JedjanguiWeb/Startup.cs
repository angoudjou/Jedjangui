using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JedjanguiWeb.Startup))]
namespace JedjanguiWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
