using AutoMapper;
using BL.Bases;
using BL.DTOs;
using BL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.AppService
{
   public class ImageAppService : BaseAppService
    {
        public ImageAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
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
   
        public bool DeleteImage(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Image.Delete(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
