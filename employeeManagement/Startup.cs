using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(employeeManagement.Startup))]
namespace employeeManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
