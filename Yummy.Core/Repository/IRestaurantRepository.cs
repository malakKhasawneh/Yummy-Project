using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Repository
{
   public interface IRestaurantRepository
    {
        int Create(Restaurant Data);
        List<Restaurant> GetAll();
        int Update(Restaurant Data);
        int Delete(int id);
        List<Restaurant> SearchRestaurant(RestaurantDTO restaurantDTO);

    }
}
