using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EssentialTools.Startup))]
namespace EssentialTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
