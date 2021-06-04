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
        public bool CreateCartProduct(string username, int id)
        {
            bool result = false;
            var user = TheUnitOfWork.Account.FindByName(username);
            //string userid = user.Result.Id;
            string userid = "244b6487-45ad-419e-9c56-711aada535c4";
            CartProduct cartProduct = new CartProduct() { productId=id,CartID= userid};
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
            CartProduct cartProductViewModel =Mapper.Map<CartProduct>( GetCartProduct(id));
            bool result = false;
            TheUnitOfWork.CardProduct.DeleteCartProduct(cartProductViewModel.ID);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckCartProductExists(int Prodectid)
        {
            var result = TheUnitOfWork.CardProduct.CheckCartProductExists(Prodectid);

            if (result)
            {
                CartProduct cartProductViewModel =Mapper.Map<CartProduct>( GetCartProduct(Prodectid));
                cartProductViewModel.quintity++;
                TheUnitOfWork.CardProduct.Update(cartProductViewModel);
                TheUnitOfWork.Commit() ;
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}
