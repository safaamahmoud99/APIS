using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.Hubs;
using BL.interfaces;
using DAL.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
   public  class WishListProductAppService : BaseAppService
    {
        private IHubContext<WishListHub, ITypedClientWishList> _hubContext;
        private IHubContext<DeleteWishListHub, ITypesClientDeleteWishList> _DeletehubContext;
        public WishListProductAppService(IHubContext<DeleteWishListHub, ITypesClientDeleteWishList> DeletehubContext, IUnitOfWork theUnitOfWork, IHubContext<WishListHub, ITypedClientWishList> hubContext) : base(theUnitOfWork)
        {
            this._hubContext = hubContext;
            this._DeletehubContext = DeletehubContext;
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
        public async Task<bool> CreateWishListProduct(string username,int id)
        {
            bool result = false;
            var user = await TheUnitOfWork.Account.FindByName(username);
            string userid =  user.Id;
            WishListProduct WishListProduct = new WishListProduct() {productId= id,WishlistID=userid };
            _hubContext.Clients.All.BroadcastMessage(WishListProduct).Wait();
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
            _DeletehubContext.Clients.All.BroadcastMessage(wishListProduct);
            return result;
        }
    }
}
