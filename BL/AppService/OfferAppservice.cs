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
    class OfferAppservice : BaseAppService
    {
        public OfferAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<BrandViewModel> GetAllOffers()
        {
            return Mapper.Map<List<BrandViewModel>>(TheUnitOfWork.Brand.GetAllBrand());
        }
        public BrandViewModel GetOffer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<BrandViewModel>(TheUnitOfWork.Brand.GetById(id));
        }
       
        public bool DeleteOffer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Offer.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }

    }
    
}
