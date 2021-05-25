﻿using BL.Bases;
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
        private DbContext EC_DbContext;
        public CardProductRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<CartProduct> GetAllCartProducts()
        {
            return GetAll().ToList();
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
        public bool CheckCartProductExists(CartProduct cartProduct)
        {
            return GetAny(b => b.ID == cartProduct.ID);
        }
        public CartProduct GetCartProductById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }
    }
}
