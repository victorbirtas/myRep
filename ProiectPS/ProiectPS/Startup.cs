using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProiectPS.Startup))]
namespace ProiectPS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
