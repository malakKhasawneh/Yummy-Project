using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository CustomerRepository;
        public CustomerServices(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public Customer Create(Customer customer)
        {
            CustomerRepository.Create(customer);
            return new Customer();
        }

        public List<Customer> GetAll()
        {
            return CustomerRepository.GetAll();

        }

        public Customer Update(Customer customer)
        {
            CustomerRepository.Update(customer);
            return customer;
        }

        public Customer Delete(int id)
        {
            CustomerRepository.Delete(id);
            return new Customer();
        }
        public object CustomerAvailability(CustomerAvailabilityDTO customerAvailabilityDTO)
        {
            return CustomerRepository.CustomerAvailability(customerAvailabilityDTO);
        }
        public List<Customer> SearchCustomerLoc(CustomerLocationDTO customerLocationDTO)
        {
            return CustomerRepository.SearchCustomerLoc(customerLocationDTO);

        }


    }
}
