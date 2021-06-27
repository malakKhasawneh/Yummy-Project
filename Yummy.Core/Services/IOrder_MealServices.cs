using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IOrder_MealServices
    {
        Order_Meal Create(Order_Meal order_Meal);
        List<Order_Meal> GetAll();
        Order_Meal Update(Order_Meal order_Meal);
        Order_Meal Delete(int id);
    }
}
