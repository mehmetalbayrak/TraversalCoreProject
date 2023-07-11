﻿using Microsoft.AspNetCore.SignalR;
using SignalRApiMSSql.Models;

namespace SignalRApiMSSql.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly VisitorService _visitorService;

        public VisitorHub(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", _visitorService.GetVisitorChartList());
        }
    }
}
