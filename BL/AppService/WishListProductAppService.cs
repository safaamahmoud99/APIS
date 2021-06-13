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
   public  class WishListProductAppService : BaseAppService
    {

        public WishListProductAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }    
        public List<WishListProductViewModel> GetAllWishListProducts(string wishlistId)
        {
            return Mapper.Map<List<WishListProductViewModel>>(TheUnitOfWork.WishListProduct.GetAllWishListProducts(wishlistId));
        }
        public WishListProductViewModel GetWishListProduct(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<WishListProductViewModel>(TheUnitOfWork.WishListProduct.GetWishListProductById(id));
        }
        public bool CreateWishListProduct(string username,int id)
        {
            bool result = false;
            var user = TheUnitOfWork.Account.FindByName(username);
            string userid =  user.Result.Id;
            WishListProduct WishListProduct = new WishListProduct() {productId= id,WishlistID=userid };
            if (TheUnitOfWork.WishListProduct.InsertWishListProduct(WishListProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool CheckWishListProductExists(int Prodectid)
        {
            var result = TheUnitOfWork.WishListProduct.CheckWishListProductExists(Prodectid);
            if(result)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeletWishListProduct(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            WishListProductViewModel wishListProduct = GetWishListProduct(id);

            TheUnitOfWork.WishListProduct.DeleteWishListProduct(wishListProduct.ID);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
