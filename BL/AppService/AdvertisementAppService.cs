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
   public  class AdvertisementAppService : BaseAppService
    {
        public AdvertisementAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<AdvertisementViewModel> GetAllAdvertisements()
        {
            return Mapper.Map<List<AdvertisementViewModel>>(TheUnitOfWork.Advertisement.GetAll());
        }
        public AdvertisementViewModel GetAdvertisement(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<AdvertisementViewModel>(TheUnitOfWork.Advertisement.GetAdvertisementById(id));
        }
        public void UpdateAdvertisement(int id, AdvertisementViewModel newadvertisement)
        {
            var advertisement = TheUnitOfWork.Advertisement.GetAdvertisementById(id);

            advertisement.StartDate = newadvertisement.StartDate;
            advertisement.EndDate= newadvertisement.EndDate;

            TheUnitOfWork.Advertisement.UpdateAdvertisement(advertisement);

        }
        public bool CreateAdvertisement(AdvertisementViewModel advertisementViewModel)
        {
            bool result = false;
            Advertisement advertisement = Mapper.Map<Advertisement>(advertisementViewModel);
            if (TheUnitOfWork.Advertisement.InsertAdvertisement(advertisement))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeletAdvertisement(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Advertisement.DeleteAdvertisement(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
