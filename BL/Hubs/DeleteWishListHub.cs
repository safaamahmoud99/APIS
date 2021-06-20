using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace BL.Hubs
{
    [HubName("DeleteWishListHub")]
    public class DeleteWishListHub : Hub<ITypesClientDeleteWishList>
    {
    }
}
