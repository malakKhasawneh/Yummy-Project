using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IReviewServices
    {

        Review Create(Review review);
        List<Review> GetAll();
        Review Update(Review review);
        Review Delete(int id);
    }
}
