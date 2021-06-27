using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class Order_MealServices : IOrder_MealServices
    {
        private readonly IOrder_MealRepository Order_MealRepository;
        public Order_MealServices(IOrder_MealRepository order_MealRepository)
        {
            Order_MealRepository = order_MealRepository;
        }
        public Order_Meal Create(Order_Meal order_Meal)
        {
            Order_MealRepository.Create(order_Meal);
            return new Order_Meal();
        }

        public List<Order_Meal> GetAll()
        {
            return Order_MealRepository.GetAll();
        }

        public Order_Meal Update(Order_Meal order_Meal)
        {
            Order_MealRepository.Update(order_Meal);
            return new Order_Meal();
        }

        public Order_Meal Delete(int id)
        {
            Order_MealRepository.Delete(id);
            return new Order_Meal();
        }
    }
}
