using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LectureSchedulingTool.Startup))]
namespace LectureSchedulingTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
