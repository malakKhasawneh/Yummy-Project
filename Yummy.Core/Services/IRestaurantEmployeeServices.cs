using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;

namespace Yummy.Core.Services
{
    public interface IRestaurantEmployeeServices
    {
        Restaurant_Employee Create(Restaurant_Employee restaurant_Employee);
        Restaurant_Employee Update(Restaurant_Employee restaurant_Employee);
        Restaurant_Employee Delete(int id);
    }
}
