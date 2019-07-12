using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OwinAuth.Startup))]
namespace OwinAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
