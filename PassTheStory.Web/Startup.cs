using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassTheStory.Web.Startup))]
namespace PassTheStory.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
