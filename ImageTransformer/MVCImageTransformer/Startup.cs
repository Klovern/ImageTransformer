using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCImageTransformer.Startup))]
namespace MVCImageTransformer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
