using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sample2.Startup))]
namespace Sample2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
