using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Razor.Startup))]
namespace Razor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
