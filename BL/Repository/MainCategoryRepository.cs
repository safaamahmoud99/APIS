using System;
using BL.Bases;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Repository
{
    public class MainCategoryRepository:BaseRepository<MainCategory>
    {
            private DbContext EC_DbContext;

            public MainCategoryRepository(DbContext EC_DbContext) : base(EC_DbContext)
            {
                this.EC_DbContext = EC_DbContext;
            }
            #region CRUd

            public List<MainCategory> GetAllMainCategory()
            {
                return GetAll().ToList();
            }

            public bool InsertMainCategory(MainCategory category)
            {
                return Insert(category);
            }
            public void UpdateMainCategory(MainCategory category)
            {
                Update(category);
            }
            public void DeleteMainCategory(int id)
            {
                Delete(id);
            }

            public bool CheckMainCategoryExists(MainCategory category)
            {
                return GetAny(l => l.ID == category.ID);
            }
            public MainCategory GetMainCategoryById(int id)
            {
                return GetFirstOrDefault(l => l.ID == id);
            }
            #endregion
        }
    }
