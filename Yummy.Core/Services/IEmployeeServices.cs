using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Services
{
    public interface IEmployeeServices
    {
        Employee Create(Employee employee);
        List<Employee> GetAll();
        Employee Update(Employee employee);
        Employee Delete(int id);
        object UserAvailability(UserAvailabilityDTO userAvailabilityDTO);

        List<object> GetAllOrder(int id);
    }
}
