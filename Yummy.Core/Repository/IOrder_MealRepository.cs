using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IOrder_MealRepository
    {
        int Create(Order_Meal Data);
        List<Order_Meal> GetAll();
        int Update(Order_Meal Data);
        int Delete(int id);
    }
}
