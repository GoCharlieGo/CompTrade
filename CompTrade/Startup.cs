﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompTrade.Startup))]
namespace CompTrade
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
