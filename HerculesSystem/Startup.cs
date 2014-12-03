using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HerculesSystem.Startup))]
namespace HerculesSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
