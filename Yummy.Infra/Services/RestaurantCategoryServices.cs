using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class RestaurantCategoryServices : IRestaurantCategoryServices
    {
        private readonly IRestaurantCategoryRepository RestaurantCategoryRepository;
        public RestaurantCategoryServices(IRestaurantCategoryRepository restaurantCategoryRepository)
        {
            RestaurantCategoryRepository = restaurantCategoryRepository;
        }

        public Restaurant_Category Create(Restaurant_Category  restaurant_Category)
        {
            RestaurantCategoryRepository.Create(restaurant_Category);
            return new Restaurant_Category();
        }

        public List<Restaurant_Category> GetAll()
        {
            return RestaurantCategoryRepository.GetAll();

        }

        public Restaurant_Category Update(Restaurant_Category restaurant_Category)
        {
            RestaurantCategoryRepository.Update(restaurant_Category);
            return restaurant_Category;
        }

        public Restaurant_Category Delete(int id)
        {
            RestaurantCategoryRepository.Delete(id);
            return new Restaurant_Category();
        }

    }
}
