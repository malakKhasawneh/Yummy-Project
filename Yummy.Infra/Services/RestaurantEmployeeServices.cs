using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
   public class RestaurantEmployeeServices : IRestaurantEmployeeServices
    {
        private readonly IRestaurantEmployeeRepository RestaurantEmployeeRepository;
        public RestaurantEmployeeServices(IRestaurantEmployeeRepository restaurantEmployeeRepository)
        {
            RestaurantEmployeeRepository = restaurantEmployeeRepository;
        }

        public Restaurant_Employee Create(Restaurant_Employee restaurant_Employee)
        {
            RestaurantEmployeeRepository.Create(restaurant_Employee);
            return new Restaurant_Employee();
        }


        public Restaurant_Employee Update(Restaurant_Employee restaurant_Employee)
        {
            RestaurantEmployeeRepository.Update(restaurant_Employee);
            return restaurant_Employee;
        }

        public Restaurant_Employee Delete(int id)
        {
            RestaurantEmployeeRepository.Delete(id);
            return new Restaurant_Employee();
        }

    }
}
