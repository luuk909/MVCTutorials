using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LanguageFeatures.Startup))]
namespace LanguageFeatures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
