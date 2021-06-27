using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Services
{
    public interface IRestaurantServices
    {
        Restaurant Create(Restaurant restaurant);
        List<Restaurant> GetAll();
        Restaurant Update(Restaurant restaurant);
        Restaurant Delete(int id);
        List<Restaurant> SearchRestaurant(RestaurantDTO restaurantDTO);

    }
}
