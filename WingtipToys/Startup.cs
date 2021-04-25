using System.Data.Entity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WingtipToys.Startup))]
namespace WingtipToys
{
    public class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
