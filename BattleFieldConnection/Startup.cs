using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BattleFieldConnection.Startup))]
namespace BattleFieldConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
