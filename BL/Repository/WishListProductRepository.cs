using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
   public  class WishListProductRepository:BaseRepository<WishListProduct>
    {

        private ApplicationDbContext EC_DbContext;
        public WishListProductRepository(ApplicationDbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<WishListProduct> GetAllWishListProducts(string wishlistId)
        {
            return EC_DbContext.wishListProducts.Where(w => w.WishlistID == wishlistId).ToList();
        }

        public bool InsertWishListProduct(WishListProduct WishListProduct)
        {
            return Insert(WishListProduct);
        }
        public void UpdateWishListProduct(WishListProduct WishListProduct)
        {
            Update(WishListProduct);
        }
        public void DeleteWishListProduct(int id)
        {
            Delete(id);
        }
        public bool CheckWishListProductExists(int id)
        {
            return GetAny(b => b.productId ==id);
        }
        public WishListProduct GetWishListProductById(int id)
        {
            return GetFirstOrDefault(b => b.productId == id);
        }
    }
}
