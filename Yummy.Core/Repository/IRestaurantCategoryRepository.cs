using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IRestaurantCategoryRepository
    {
        int Create(Restaurant_Category Data);
        List<Restaurant_Category> GetAll();
        int Update(Restaurant_Category Data);
        int Delete(int id);
    }
}
