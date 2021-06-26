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
   public class ImageAppService : BaseAppService
    {
        public ImageAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
        {

        }
        public List<ImageViewModel> GetAllImages()
        {
            return Mapper.Map<List<ImageViewModel>>(TheUnitOfWork.Image.GetAllImage());
        }
        public ImageViewModel GetImage(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<ImageViewModel>(TheUnitOfWork.Image.GetById(id));
        }

        public bool CreateImage(ImageViewModel imageViewModel)
        {
            if (imageViewModel == null)

                throw new ArgumentNullException();



            bool result = false;
            var image = Mapper.Map<Images>(imageViewModel);
            if (TheUnitOfWork.Image.Insert(image))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeleteImage(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Image.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
        public bool UpdateImage(ImageViewModel imageViewModel)
        {
            var image = Mapper.Map<Images>(imageViewModel);
            TheUnitOfWork.Image.Update(image);
            TheUnitOfWork.Commit();

            return true;
        }
        public bool CheckImageExists(int imageId)
        {
            var result = TheUnitOfWork.Image.CheckImageExists(imageId);

            if (result)
            {
                return true;
            }
            return false;
        }
        public int CountEntity()
        {
            return TheUnitOfWork.Image.CountEntity();
        }
        public IEnumerable<ImageViewModel> GetPageRecords(int pageSize, int pageNumber)
        {
            return Mapper.Map<List<ImageViewModel>>(TheUnitOfWork.Image.GetPageRecords(pageSize, pageNumber));
        }
    }
}
