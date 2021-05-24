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
    class OrderRepository:BaseRepository<Order>
    {
        private DbContext EC_DbContext;

        public OrderRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        #region CRUB

        public List<Order> GetAllOrder()
        {
            return GetAll().Include(order => order.User).ToList();
        }

        public bool InsertOrder(Order order)
        {
            return Insert(order);
        }
        public void UpdateOrder(Order order)
        {
            Update(order);
        }
        public void DeleteOrder(int id)
        {
            Delete(id);
        }

        public bool CheckOrderExists(Order order)
        {
            return GetAny(l => l.ID == order.ID);
        }
        public Order GetOrderById(int id)
        {
            return GetFirstOrDefault(l => l.ID == id);
        }

        #endregion
        public override int CountEntity()
        {
            return DbSet.Count();
        }
        public int CountEntityForSpeCifcUser(string userID)
        {
            return DbSet.Where(o => o.UserID == userID).Count();
        }
        public override IEnumerable<Order> GetPageRecords(int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;

            var kk = DbSet.Skip(pageNumber * pageSize).Take(pageSize).Include(order => order.User);

            return DbSet.Skip(pageNumber * pageSize).Take(pageSize).Include(order => order.User);
        }
        public IEnumerable<Order> GetPageRecordsForSpeceficUser(string userID, int pageSize, int pageNumber)
        {
            pageSize = (pageSize <= 0) ? 10 : pageSize;
            pageNumber = (pageNumber < 1) ? 0 : pageNumber - 1;

            return DbSet.Where(o => o.UserID == userID).Skip(pageNumber * pageSize).Take(pageSize).Include(order => order.User);


        }

    }

}
