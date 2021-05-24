using BL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.interfaces
{
   public interface IUnitOfWork:IDisposable
    {
        int Commit();
        CartRepository Cart { get; }
        BrandRepository Brand { get; set; }
        ImageRepository Image { get; set; }
        SupplierRepository Supplier { get; set; }
        WishListRepository wishList { get; }
        AccountRepository Account { get; }
    }
}
