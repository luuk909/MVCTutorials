using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PartyInvites.Startup))]
namespace PartyInvites
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
