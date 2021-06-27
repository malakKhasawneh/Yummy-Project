using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Repository
{
    public interface ICustomerRepository
    {
        int Create(Customer Data);
        List<Customer> GetAll();
        int Update(Customer Data);
        int Delete(int id);
        object CustomerAvailability(CustomerAvailabilityDTO customerAvailabilityDTO);
        List<Customer> SearchCustomerLoc(CustomerLocationDTO customerLocationDTO);


    }
}
