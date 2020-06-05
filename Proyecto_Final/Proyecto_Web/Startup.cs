using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyecto_Web.Startup))]
namespace Proyecto_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
