using ECommerceBackend.Application.Abstractions.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBackend.SignalR.HubServices
{
    public class OrderHubService : IOrderHubService
    {
        public Task OrderAddedMessageAsync(string message)
        {
            throw new NotImplementedException();
        }
    }
}
