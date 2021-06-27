using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
   public  interface IRestaurantCategoryServices
    {
        Restaurant_Category Create(Restaurant_Category restaurant_Category);
        List<Restaurant_Category> GetAll();
        Restaurant_Category Update(Restaurant_Category restaurant_Category);
        Restaurant_Category Delete(int id);
    }
}
