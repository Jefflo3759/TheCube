using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheCube.Web.Startup))]
namespace TheCube.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
