using Microsoft.Owin;

using MvcForum.App;

[assembly: OwinStartup(typeof(Startup))]

namespace MvcForum.App
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}