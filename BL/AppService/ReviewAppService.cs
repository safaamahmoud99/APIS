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
   public  class ReviewAppService : BaseAppService
    {
        public ReviewAppService(IUnitOfWork theUnitOfWork, IMapper mapper) : base(theUnitOfWork, mapper)
        {

        }
        public List<ReviewViewModel> GetAllReviews()
        {
            return Mapper.Map<List<ReviewViewModel>>(TheUnitOfWork.Review.GetAll());
        }
        public ReviewViewModel GetReview(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            return Mapper.Map<ReviewViewModel>(TheUnitOfWork.Review.GetReviewById(id));
        }
        public bool CreateReview(int id)
        {
            bool result = false;
            Review Review = new Review() { ID = id };
            if (TheUnitOfWork.Review.InsertReview(Review))
            {
                result = TheUnitOfWork.Commit() > new int();
            }
            return result;
        }
        public bool DeletReview(int id)
        {
            if (id < 0)
                throw new ArgumentNullException();
            bool result = false;
            TheUnitOfWork.Review.DeleteReview(id);
            result = TheUnitOfWork.Commit() > new int();
            return result;
        }
    }
}
