using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaGrandeSAS.Startup))]
namespace LaGrandeSAS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
