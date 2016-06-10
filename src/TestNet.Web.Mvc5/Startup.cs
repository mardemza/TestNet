using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestNet.Web.Mvc5.Startup))]
namespace TestNet.Web.Mvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
