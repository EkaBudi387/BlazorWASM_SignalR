using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Server.Hubs
{
    public class RecordHub:Hub
    {

        public async Task SendMessage()
        {
            await Clients.All.SendAsync("ReceiveMessage");
        }

    }
}
