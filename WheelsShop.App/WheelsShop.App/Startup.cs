using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WheelsShop.App.Startup))]
namespace WheelsShop.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
