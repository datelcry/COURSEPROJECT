using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCsite.Startup))]
namespace MVCsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
