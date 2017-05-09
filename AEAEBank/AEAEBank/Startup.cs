using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AEAEBank.Startup))]
namespace AEAEBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
