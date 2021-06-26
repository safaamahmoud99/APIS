using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using BL.Hubs;

namespace BL.Hubs
{
    [HubName("SoppingCartWishListHub")]
    public class SoppingCartWishListHub:Hub<ITypedHubClient>
    {

    }
}
