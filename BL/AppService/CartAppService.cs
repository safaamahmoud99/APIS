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
    public class CartAppService:BaseAppService
    {

        public CartAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<CartViewModel> GetAllCarts()
        {
            return Mapper.Map<List<CartViewModel>>(TheUnitOfWork.Cart.GetAllCart());
        }
        public CartViewModel GetCart(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<CartViewModel>(TheUnitOfWork.Cart.GetById(id));
        }
        public bool CreateUserCart(int userId)
        {
            bool result = false;
            Cart userCart = new Cart() { ID = userId };
            if (TheUnitOfWork.Cart.Insert(userCart))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteCart(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Cart.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

    }
}
