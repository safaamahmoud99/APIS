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
   public class SubCategoryAppService:BaseAppService
    {
        public SubCategoryAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }

        public List<SubCategoryViewModel> GetAllSubCateogries()
        {

            return Mapper.Map<List<SubCategoryViewModel>>(TheUnitOfWork.SubCategory.GetAllSubCategory());
        }
        public SubCategoryViewModel GetSubCategory(int id)
        {
            return Mapper.Map<SubCategoryViewModel>(TheUnitOfWork.SubCategory.GetById(id));
        }



        public bool AddNewCategory(SubCategoryViewModel categoryViewModel)
        {
            if (categoryViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var category = Mapper.Map<SubCategory>(categoryViewModel);
            if (TheUnitOfWork.SubCategory.Insert(category))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }


        public bool UpdateSubCategory(SubCategoryViewModel categoryViewModel)
        {
            var category = Mapper.Map<SubCategory>(categoryViewModel);
            TheUnitOfWork.SubCategory.Update(category);
            TheUnitOfWork.Commit();

            return true;
        }


        public bool DeleteSubCategory(int id)
        {
            bool result = false;

            TheUnitOfWork.SubCategory.Delete(id);
            result = TheUnitOfWork.Commit() > new int();

            return result;
        }

        public bool CheckCategoryExists(SubCategoryViewModel categoryViewModel)
        {
            SubCategory category = Mapper.Map<SubCategory>(categoryViewModel);
            return TheUnitOfWork.SubCategory.CheckSubCategoryExists(category);
        }
    }
}
