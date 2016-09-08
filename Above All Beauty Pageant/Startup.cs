using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Above_All_Beauty_Pageant.Startup))]
namespace Above_All_Beauty_Pageant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
