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
        public bool CreateBrand(int userId)
        {
            bool result = false;
            Brands userBrand = new Brands() { ID = userId };
            if (TheUnitOfWork.Brand.Insert(userBrand))
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

    }
}
