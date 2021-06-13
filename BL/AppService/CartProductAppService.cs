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
        public List<CartProductViewModel> GetAllCartProducts(string cartId)
        {
            return Mapper.Map<List<CartProductViewModel>>(TheUnitOfWork.CardProduct.GetAllCartProducts(cartId));
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
            var pro = TheUnitOfWork.Product.GetProductById(id);

       
            string userid = user.Result.Id;
            //string userid = "e2622172-be88-4483-8585-6649a8f956c2";
            var pro = TheUnitOfWork.Product.GetProductById(id);      
            string userid = user.Result.Id;
            var cart = TheUnitOfWork.Cart.GetCartById(userid);
           
            CartProduct cartProduct = new CartProduct() { productId=id,CartID= userid,NetPrice=pro.Price};
            cart.TotalPrice += cartProduct.NetPrice;
            if (TheUnitOfWork.CardProduct.InsertCartProduct(cartProduct))
            {
                TheUnitOfWork.Cart.UpdateCart(cart);
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
        public bool CheckCartProductExists(int Prodectid,string username)
        {
            var result = TheUnitOfWork.CardProduct.CheckCartProductExists(Prodectid);
            var pro = TheUnitOfWork.Product.GetProductById(Prodectid);
            var user = TheUnitOfWork.Account.FindByName(username);
            


            string userid = user.Result.Id;
            //string userid = "e2622172-be88-4483-8585-6649a8f956c2";
            var user = TheUnitOfWork.Account.FindByName(username);
            string userid = user.Result.Id;
            var cart = TheUnitOfWork.Cart.GetCartById(userid);
            if (result)
            {
                CartProduct cartProductViewModel =Mapper.Map<CartProduct>( GetCartProduct(Prodectid));
                cartProductViewModel.quintity++;
                cartProductViewModel.NetPrice += pro.Price;
                cart.TotalPrice += pro.Price;
                TheUnitOfWork.Cart.UpdateCart(cart);
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
