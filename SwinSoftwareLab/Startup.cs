using Microsoft.Owin;
using MoreLinq.Extensions;
using Owin;
using SwinSoftwareLab.Models;
using System.Collections.Generic;
using System.Linq;

[assembly: OwinStartupAttribute(typeof(SwinSoftwareLab.Startup))]
namespace SwinSoftwareLab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
