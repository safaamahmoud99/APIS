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
   public class BrandRepository : BaseRepository<Brands>
    {
        private DbContext EC_DbContext;
        public BrandRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<Brands> GetAllBrand()
        {
            return GetAll().ToList();
        }

        public bool InsertBrand(Brands brand)
        {
            return Insert(brand);
        }
        public void UpdateBrand(Brands brand)
        {
            Update(brand);
        }
        public void DeleteBrand(int id)
        {
            Delete(id);
        }
        public bool CheckBrandExists(int id)
        {
            return GetAny(b => b.ID == id);
        }
            public Brands GetBrandById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }
    }
}
