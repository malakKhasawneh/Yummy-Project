using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IRestaurantEmployeeRepository
    {
        int Create(Restaurant_Employee Data);
        int Update(Restaurant_Employee Data);
        int Delete(int id);
    }
}
