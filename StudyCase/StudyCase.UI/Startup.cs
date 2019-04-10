using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyCase.UI.Startup))]
namespace StudyCase.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
