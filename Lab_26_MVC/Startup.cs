using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab_26_MVC.Startup))]
namespace Lab_26_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
