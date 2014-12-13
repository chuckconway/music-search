using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicSearch.Startup))]
namespace MusicSearch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
