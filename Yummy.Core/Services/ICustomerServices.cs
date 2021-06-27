using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Services
{
    public interface ICustomerServices
    {
        Customer Create(Customer customer);
        List<Customer> GetAll();
        Customer Update(Customer customer);
        Customer Delete(int id);
        object CustomerAvailability(CustomerAvailabilityDTO customerAvailabilityDTO);
        List<Customer> SearchCustomerLoc(CustomerLocationDTO customerLocationDTO);


    }
}
