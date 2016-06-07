using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JayMayNN3.Startup))]
namespace JayMayNN3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
