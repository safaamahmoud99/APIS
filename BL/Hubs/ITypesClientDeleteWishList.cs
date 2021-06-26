using BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Hubs
{
    public interface ITypesClientDeleteWishList
    {
        Task BroadcastMessage(WishListProductViewModel wishListProduct);
    }
}
