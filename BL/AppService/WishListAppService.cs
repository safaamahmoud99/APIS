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
        public WishListAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<WishListViewModel> GetAllWishlists()
        {
            return Mapper.Map<List<WishListViewModel>>(TheUnitOfWork.wishList.GetAllWishlist());
        }
        public WishListViewModel GetWishlist(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<WishListViewModel>(TheUnitOfWork.wishList.GetById(id));
        }
        public bool CreateUserWishlist(string userId)
        {
            bool result = false;
            WishList userWishlist = new WishList() { ID = userId };
            if (TheUnitOfWork.wishList.Insert(userWishlist))
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

            TheUnitOfWork.wishList.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }
    }
}
