using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IReviewRepository
    {
        int Create(Review Data);
        List<Review> GetAll();
        int Update(Review Data);
        public int Delete(int id);
    }
}
