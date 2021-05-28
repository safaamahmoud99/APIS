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
        public ReviewAppService(IUnitOfWork theUnitOfWork) : base(theUnitOfWork)
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
        public void UpdateReview(int id, ReviewViewModel newreview)
        {
            var review = TheUnitOfWork.Review.GetReviewById(id);

            review.Comment = newreview.Comment;
            review.Rating = newreview.Rating;

            TheUnitOfWork.Review.UpdateReview(review);

        }
        public bool CreateReview(ReviewViewModel reviewViewModel)
        {
            bool result=false;
            Review review = Mapper.Map<Review>(reviewViewModel);
            if (TheUnitOfWork.Review.InsertReview(review))
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
