using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidli.Startup))]
namespace Vidli
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
