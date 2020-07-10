using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternPlatform.Startup))]
namespace InternPlatform
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
