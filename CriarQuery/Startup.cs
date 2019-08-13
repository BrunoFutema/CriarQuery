using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CriarQuery.Startup))]
namespace CriarQuery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
