using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentralNNApp.Startup))]
namespace CentralNNApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
