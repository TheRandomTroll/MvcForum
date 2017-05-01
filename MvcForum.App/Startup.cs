using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcForum.App.Startup))]
namespace MvcForum.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
