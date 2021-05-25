using System;
using BL.Bases;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class SubCategoryRepository:BaseRepository<SubCategory>
    {
        private DbContext EC_DbContext;
        public SubCategoryRepository(DbContext EC_DbContext) : base(EC_DbContext)
        {
            this.EC_DbContext = EC_DbContext;
        }
        public List<SubCategory> GetAllBrand()
        {
            return GetAll().ToList();
        }

        public bool InsertSubCategory(SubCategory cat)
        {
            return Insert(cat);
        }
        public void UpdateSubCategory(SubCategory cat)
        {
            Update(cat);
        }
        public void DeleteSubCategory(int id)
        {
            Delete(id);
        }
        public bool CheckSubCategoryExists(SubCategory cat)
        {
            return GetAny(b => b.ID == cat.ID);
        }
        public SubCategory GetSubCategoryById(int id)
        {
            return GetFirstOrDefault(b => b.ID == id);
        }
    }
}
