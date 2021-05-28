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
    public class WishListAppService:BaseAppService
    {
        public WishListAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<WishListViewModel> GetAllWishlists()
        {
            return Mapper.Map<List<WishListViewModel>>(TheUnitOfWork.WishList.GetAllWishlist());
        }
        public WishListViewModel GetWishlist(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<WishListViewModel>(TheUnitOfWork.WishList.GetById(id));
        }
        public bool CreateUserWishlist(string userId)
        {
            bool result = false;
            WishList userWishlist = new WishList() { UserID = userId };
            if (TheUnitOfWork.WishList.Insert(userWishlist))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteWishlist(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;

            TheUnitOfWork.WishList.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
    }
}
