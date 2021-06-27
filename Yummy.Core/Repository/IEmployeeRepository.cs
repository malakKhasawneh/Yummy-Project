using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Repository
{
    public interface IEmployeeRepository
    {
        int Create(Employee Data);
        List<Employee> GetAll();
        int Update(Employee Data);
        int Delete(int id);
        object UserAvailability(UserAvailabilityDTO userAvailabilityDTO);
        List<object> GetAllOrder(int id);


    }
}
