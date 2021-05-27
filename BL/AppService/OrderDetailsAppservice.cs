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
    public class OrderDetailsAppservice : BaseAppService
    {
        public OrderDetailsAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
      

        public List<OrderDetailsViewModel> GetAllOrderDetails()
        {

            return Mapper.Map<List<OrderDetailsViewModel>>(TheUnitOfWork.Orderdetails.GetAll());
        }
        


        public bool SaveNewOrder(OrderDetailsViewModel orderProductViewModel)
        {

            bool result = false;
            var orderProduct = Mapper.Map<OrderDetails>(orderProductViewModel);
            if (TheUnitOfWork.Orderdetails.Insert(orderProduct))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


         
 
    
    }
}
