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
    public class BrandAppService : BaseAppService
    {
        public BrandAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<BrandViewModel> GetAllBrands()
        {
            return Mapper.Map<List<BrandViewModel>>(TheUnitOfWork.Brand.GetAllBrand());
        }
        public BrandViewModel GetBrand(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<BrandViewModel>(TheUnitOfWork.Brand.GetById(id)); 
        }
        public bool CreateBrand(BrandViewModel  brandViewModel)
        {
            if (brandViewModel == null)

                throw new ArgumentNullException();



            bool result = false;
            var brand = Mapper.Map<Brands>(brandViewModel);
            if (TheUnitOfWork.Brand.Insert(brand))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteBrand(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Brand.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

        public bool CheckBrandExists(int brandId)
        {
            var result = TheUnitOfWork.Brand.CheckBrandExists(brandId);

            if(result)
            {
                return true;
            }
            return false;
        }

        public bool UpdateBrand(BrandViewModel brandViewModel)
        {
            var brand = Mapper.Map<Brands>(brandViewModel);
            TheUnitOfWork.Brand.Update(brand); 
            TheUnitOfWork.Commit();

            return true;
        }
    }
}
