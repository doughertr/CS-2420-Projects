using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleListApplication.Startup))]
namespace PeopleListApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
