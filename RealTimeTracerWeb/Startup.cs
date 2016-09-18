using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealTimeTracerWeb
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR("/realtimetrace", new Microsoft.AspNet.SignalR.HubConfiguration());
        }

    }
}