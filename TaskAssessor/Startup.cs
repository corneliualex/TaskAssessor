using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TaskAssessor.Startup))]
namespace TaskAssessor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
