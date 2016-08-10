using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HomeShare.Startup))]
namespace HomeShare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
