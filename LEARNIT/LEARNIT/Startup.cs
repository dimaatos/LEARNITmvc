using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LEARNIT.Startup))]
namespace LEARNIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
