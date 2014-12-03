using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hercules.Startup))]
namespace Hercules
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
