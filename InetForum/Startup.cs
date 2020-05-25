using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InetForum.Startup))]
namespace InetForum
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
