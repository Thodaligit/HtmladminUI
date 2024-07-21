using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdminUI.Startup))]
namespace AdminUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
