using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnythingAndEverything.Startup))]
namespace AnythingAndEverything
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
