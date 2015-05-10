using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebBlack.Startup))]
namespace WebBlack
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
