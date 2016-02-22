using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeReferralApp.Startup))]
namespace EmployeeReferralApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
