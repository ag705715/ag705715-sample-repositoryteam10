using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MIS4200AndrewGolik.Startup))]
namespace MIS4200AndrewGolik
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
