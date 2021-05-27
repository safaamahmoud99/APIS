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
    public class OrderAppService : BaseAppService
    {
        public OrderAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        

        public List<OrderViewModel> GetAllOrder()
        {

            return Mapper.Map<List<OrderViewModel>>(TheUnitOfWork.Order.GetAllOrder());
        }
        public OrderViewModel GetOrder(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException();
            return Mapper.Map<OrderViewModel>(TheUnitOfWork.Order.GetOrderById(id));
        }



        public bool SaveNewOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
                throw new ArgumentNullException();
            if (orderViewModel == null || orderViewModel.User_Id == string.Empty)
                throw new ArgumentException();
            bool result = false;
            var order = Mapper.Map<Order>(orderViewModel);
            if (TheUnitOfWork.Order.Insert(order))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateOrder(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
                throw new ArgumentNullException();
            if (orderViewModel.User_Id == null || orderViewModel.User_Id == string.Empty)
                throw new ArgumentException();
            var order = Mapper.Map<Order>(orderViewModel);
            TheUnitOfWork.Order.Update(order);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteOrder(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException();

            bool result = false;

            TheUnitOfWork.Order.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckOrderExists(OrderViewModel orderViewModel)
        {
            if (orderViewModel == null)
                throw new ArgumentNullException();
            if (orderViewModel.User_Id == null || orderViewModel.User_Id == string.Empty)
                throw new ArgumentException();
            Order order = Mapper.Map<Order>(orderViewModel);
            return TheUnitOfWork.Order.CheckOrderExists(order);
        }
      
        
        
        

    }
     
}
