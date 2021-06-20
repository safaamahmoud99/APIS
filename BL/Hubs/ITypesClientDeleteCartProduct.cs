using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Hubs
{
    public interface ITypesClientDeleteCartProduct
    {
        Task BroadcastMessage(CartProduct cartProduct);
    }
}
