

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VoiceoverIP.Startup))]
namespace VoiceoverIP
{

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }

}