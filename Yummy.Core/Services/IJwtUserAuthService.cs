using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IJwtUserAuthService
    {
        string EmployeeAuthenticate(Employee employee);
        string CustomerAuthenticate(Customer customer);


    }
}
