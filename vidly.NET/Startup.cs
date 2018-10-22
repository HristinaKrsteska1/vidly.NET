using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vidly.NET.Startup))]
namespace vidly.NET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
