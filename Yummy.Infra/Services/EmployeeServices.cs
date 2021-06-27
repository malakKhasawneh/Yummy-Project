using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
   public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository EmpRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            EmpRepository = employeeRepository;
        }

        public Employee Create(Employee employee)
        {
            EmpRepository.Create(employee);
            return new Employee();
        }

        public List<Employee> GetAll()
        {
            return EmpRepository.GetAll();

        }

        public Employee Update(Employee employee)
        {
            EmpRepository.Update(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            EmpRepository.Delete(id);
            return new Employee();
        }
        public object UserAvailability(UserAvailabilityDTO userAvailabilityDTO)
        {
            return EmpRepository.UserAvailability(userAvailabilityDTO);
        }
        public List<object> GetAllOrder(int id)
        {
            return  EmpRepository.GetAllOrder(id);
        }
    }

}
