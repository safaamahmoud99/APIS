using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace BL.Hubs
{
    [HubName("WishListHub")]
    public class WishListHub:Hub<ITypedClientWishList>
    {
    }
}
