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
    public class MainCategoryAppService:BaseAppService
    {
        public MainCategoryAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }

        public List<MainCategoryViewModel> GetAllMainCateogries()
        {

            return Mapper.Map<List<MainCategoryViewModel>>(TheUnitOfWork.MainCategory.GetAllMainCategory());
        }
        public MainCategoryViewModel GetMainCategory(int id)
        {
            return Mapper.Map<MainCategoryViewModel>(TheUnitOfWork.MainCategory.GetById(id));
        }



        public bool AddMainCategory(MainCategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var category = Mapper.Map<MainCategory>(categoryViewModel);
            if (TheUnitOfWork.MainCategory.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateMainCategory(MainCategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<MainCategory>(categoryViewModel);
            TheUnitOfWork.MainCategory.Update(category);
            TheUnitOfWork.Commit();
            return true;
        }


        public bool DeletMaineCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.MainCategory.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckMainCategoryExists(MainCategoryViewModel categoryViewModel)
        {
            MainCategory category = Mapper.Map<MainCategory>(categoryViewModel);
            return TheUnitOfWork.MainCategory.CheckMainCategoryExists(category);
        }
        public int CountEntity()
        {
            return TheUnitOfWork.MainCategory.CountEntity();
        }
        public IEnumerable<MainCategoryViewModel> GetPageRecords(int pageSize, int pageNumber)
        {
            return Mapper.Map<List<MainCategoryViewModel>>(TheUnitOfWork.MainCategory.GetPageRecords(pageSize, pageNumber));
        }
    }
}
