using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSConsumer.Startup))]
namespace MSConsumer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
