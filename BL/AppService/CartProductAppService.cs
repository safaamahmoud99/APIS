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
        public async Task<bool> CreateCartProduct(string username, int id)
        {
            bool result = false;
            var user =await TheUnitOfWork.Account.FindByName(username);
            var pro = TheUnitOfWork.Product.GetProductById(id);      
            string userid = user.Id;
            var cart = TheUnitOfWork.Cart.GetCartById(userid);
           
            CartProduct cartProduct = new CartProduct() { productId=id,CartID= userid,NetPrice=pro.Price};
            cart.TotalPrice += cartProduct.NetPrice;
            if (TheUnitOfWork.CardProduct.InsertCartProduct(cartProduct))
            {
                TheUnitOfWork.Cart.UpdateCart(cart);
                result = TheUnitOfWork.Commit() > new int();
               
            }
            return  result;
        }
        public async Task<bool> DeletCartProduct(int id,string username)
        {
            if (id < 0)
                throw new ArgumentNullException();

            var user = await TheUnitOfWork.Account.FindByName(username);
            string userid = user.Id;
            var cart = TheUnitOfWork.Cart.GetCartById(userid);
           
            CartProduct cartProductViewModel =Mapper.Map<CartProduct>( GetCartProduct(id));
            cart.TotalPrice -= cartProductViewModel.NetPrice;
           bool result = false;
           
            TheUnitOfWork.CardProduct.DeleteCartProduct(cartProductViewModel.ID);
            TheUnitOfWork.Cart.UpdateCart(cart);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public async Task<bool> DeletAllCartProduct(string cartID)
        {
            var user = await TheUnitOfWork.Account.FindById(cartID);

            var cart = TheUnitOfWork.Cart.GetCartById(cartID);
            bool result = false;
            foreach(var cartproduct in cart.cartProducts)
            {
                TheUnitOfWork.CardProduct.DeleteCartProduct(cartproduct.ID);
            }
            
            cart.TotalPrice = 0;
            cart.cartProducts.Clear();
            TheUnitOfWork.Cart.UpdateCart(cart);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool CheckCartProductExists(int Prodectid,string username)
        {
            var result = TheUnitOfWork.CardProduct.CheckCartProductExists(Prodectid);
            var pro = TheUnitOfWork.Product.GetProductById(Prodectid);
           
            


            
           
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


        public async Task<bool> UpdateCartProduct( CartProductViewModel newcartProduct, string username)
        {
            
            bool result = false;
            var user = await TheUnitOfWork.Account.FindByName(username);
            string userid = user.Id;
            var cart = TheUnitOfWork.Cart.GetCartById(userid);

            var pro = TheUnitOfWork.Product.GetProductById(newcartProduct.productId);
            var cartProduct = TheUnitOfWork.CardProduct.GetCartProductByCartProductId(newcartProduct.ID);

            cart.TotalPrice -= cartProduct.NetPrice;
            

            cartProduct.quintity = newcartProduct.quintity;
            cartProduct.NetPrice = cartProduct.quintity * pro.Price;
            cart.TotalPrice += cartProduct.NetPrice;
            TheUnitOfWork.Cart.UpdateCart(cart);
            TheUnitOfWork.CardProduct.UpdateCartProduct(cartProduct);

            result = TheUnitOfWork.Commit() > new int();

            
            return result;



            
        }

    }
}
