using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_70322_Yushkevich.Startup))]
namespace _70322_Yushkevich
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
