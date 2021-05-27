using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
   public  class CartProductAppService :BaseAppService
    {
        public CartProductAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<CartProductViewModel> GetAllCartProducts()
        {
            return Mapper.Map<List<CartProductViewModel>>(TheUnitOfWork.CardProduct.GetAll());
        }
        public CartProductViewModel GetCartProduct(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<CartProductViewModel>(TheUnitOfWork.CardProduct.GetCartProductById(id));
        }
        public bool CreateCartProduct(int id)
        {
            bool result = false;
            CartProduct cartProduct = new CartProduct() { ID = id };
            if (TheUnitOfWork.CardProduct.InsertCartProduct(cartProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeletCartProduct(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.CardProduct.DeleteCartProduct(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
