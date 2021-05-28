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
   public class SupplierRepository : BaseRepository<Suppliers>
    {
        private DbContext EC_DbContext;
        public SupplierRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Suppliers> GetAllSupplier()
        {
            return GetAll().ToList();
        }

        public bool InsertSupplier(Suppliers supplier)
        {
            return Insert(supplier);
        }
        public void UpdateSupplier(Suppliers supplier)
        {
            Update(supplier);
        }
        public void DeleteSupplier(int id)
        {
            Delete(id);
        }
        public bool CheckSupplierExists(Suppliers supplier)
        {
            return GetAny(S => S.ID == supplier.ID);
        }
        public Suppliers GetSupplierById(int id)
        {
            return GetFirstOrDefault(S => S.ID == id);
        }
    }
}
