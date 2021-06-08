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
   public  class CardProductRepository : BaseRepository<CartProduct>
    {
        private ApplicationDbContext EC_DbContext;
        public CardProductRepository(ApplicationDbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<CartProduct> GetAllCartProducts(string cartId)
        {
            return EC_DbContext.cartProducts.Where(c => c.CartID == cartId).ToList();
        }

        public bool InsertCartProduct(CartProduct cartProduct)
        {
            return Insert(cartProduct);
        }
        public void UpdateCartProduct(CartProduct cartProduct)
        {
            Update(cartProduct);
        }
        public void DeleteCartProduct(int id)
        {
            Delete(id);
        }
        public bool CheckCartProductExists(int id)
        {
            return GetAny(b => b.productId == id);
        }
        public CartProduct GetCartProductById(int id)
        {
            return GetFirstOrDefault(b => b.productId == id);
        }
    }
}
