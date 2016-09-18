using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace RealTimeTracerWeb
{
    public class TraceListenerHub : Hub
    {
        public TraceListenerHub()
        {

        }

        public override async Task OnConnected()
        {
            var channel = 
                this.Context.QueryString["channel"];

            if (String.IsNullOrEmpty(channel))
            {
                this.Context.Request.GetHttpContext().Response.End();
                return;
            }

            Clients.Group(channel).onJoin(Context.ConnectionId);

            await this.Groups.Add(Context.ConnectionId, channel);
            await base.OnConnected();
        }

        public void Trace(string channel, string message)
        {
            if (!String.IsNullOrEmpty(channel))
                Clients.Group(channel).onTrace(Context.ConnectionId, message);
        }
    }

}