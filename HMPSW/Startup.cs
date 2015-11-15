using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HMPSW.Startup))]
namespace HMPSW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
