using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class RestaurantServices : IRestaurantServices
    {
        private readonly IRestaurantRepository RestaurantRepository;
        public RestaurantServices(IRestaurantRepository restaurantRepository)
        {
            RestaurantRepository = restaurantRepository;
        }

        public Restaurant Create(Restaurant restaurant)
        {
            RestaurantRepository.Create(restaurant);
            return new Restaurant();
        }

        public List<Restaurant> GetAll()
        {
            return RestaurantRepository.GetAll();

        }

        public Restaurant Update(Restaurant restaurant)
        {
            RestaurantRepository.Update(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            RestaurantRepository.Delete(id);
            return new Restaurant();
        }
        public List<Restaurant> SearchRestaurant(RestaurantDTO restaurantDTO)
        {
            return RestaurantRepository.SearchRestaurant(restaurantDTO);
        }

    }
}
