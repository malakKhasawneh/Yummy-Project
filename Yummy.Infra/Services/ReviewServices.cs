using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class ReviewServices : IReviewServices
    {
        private readonly IReviewRepository ReviewRepository;
        public ReviewServices(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        public Review Create(Review review)
        {
            ReviewRepository.Create(review);
            return new Review();
        }


        public List<Review> GetAll()
        {
            return ReviewRepository.GetAll();
        }
        public Review Update(Review review)
        {
            ReviewRepository.Update(review);
            return new Review();
        }
        public Review Delete(int id)
        {
            ReviewRepository.Delete(id);
            return new Review();
        }
    }
}
