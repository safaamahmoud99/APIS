using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL.Repository
{
   public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        private DbContext EC_DbContext;

        public OrderDetailsRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }



        public List<OrderDetails> GetAllOrderProduct()
        {
            return GetAll().ToList();
        }

        public bool InsertOrderDetails(OrderDetails orderDetails)
        {
            return Insert(orderDetails);
        }
        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            Update(orderDetails);
        }
        public void DeleteOrder(int id)
        {
            Delete(id);
        }

        

    
    
    }
}
