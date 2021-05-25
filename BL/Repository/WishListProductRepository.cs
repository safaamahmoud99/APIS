using BL.Bases;
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

        private DbContext EC_DbContext;
        public WishListProductRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<WishListProduct> GetAllWishListProducts()
        {
            return GetAll().ToList();
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
        public bool CheckWishListProductExists(WishListProduct WishListProduct)
        {
            return GetAny(b => b.ID == WishListProduct.ID);
        }
        public WishListProduct GetWishListProductById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }
    }
}
