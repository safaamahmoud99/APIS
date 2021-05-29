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
   public class OfferAppservice : BaseAppService
    {
        public OfferAppservice(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<OfferViewModel> GetAllOffers()
        {
            return Mapper.Map<List<OfferViewModel>>(TheUnitOfWork.Offer.GetAllOffer());
        }
        public bool AddOffer(OfferViewModel offerViewModel )
        {
            if (offerViewModel == null)

                throw new ArgumentNullException();

            bool result = false;
            var offer = Mapper.Map<Offer>(offerViewModel);
            if (TheUnitOfWork.Offer.Insert(offer))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public OfferViewModel GetOffer(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<OfferViewModel>(TheUnitOfWork.Offer.GetById(id));
        }
        public bool UpdateOffer(OfferViewModel offerViewModel)
        {
            var offer = Mapper.Map<Offer>(offerViewModel);
            TheUnitOfWork.Offer.Update(offer);
            TheUnitOfWork.Commit();
            return true;
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
