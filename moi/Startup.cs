using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(moi.Startup))]
namespace moi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
