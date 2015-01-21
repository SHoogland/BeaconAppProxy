using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeaconAppProxy.Startup))]
namespace BeaconAppProxy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
