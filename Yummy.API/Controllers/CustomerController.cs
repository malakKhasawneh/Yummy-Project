using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Services;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerServices CustomerService;
        public CustomerController(ICustomerServices customerService)
        {
            CustomerService = customerService;
        }
        [Authorize("Call Center")]
        [HttpPost]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status400BadRequest)]
        public Customer Create([FromBody] Customer customer)
        {
            return CustomerService.Create(customer);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
        public List<Customer> GetAll()
        {
            return CustomerService.GetAll();
        }
        // who can update customer ? 
        [Authorize("Customer")]
        [HttpPut]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status400BadRequest)]
        public Customer Update([FromBody] Customer customer)
        {
            return CustomerService.Update(customer);
        }
        // who can delete customer ? 
        [HttpDelete("{id}")]
        public Customer Delete(int id)
        {
            return CustomerService.Delete(id);

        }
        [HttpPost]
        [Route("check")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public object CustomerAvailability([FromBody] CustomerAvailabilityDTO customerAvailabilityDTO)
        {
            return CustomerService.CustomerAvailability(customerAvailabilityDTO);
        }
        [Authorize("Delivery")]
        [HttpPost]
        [Route("CustomerLocationSearch")]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status400BadRequest)]
        public List<Customer> Search([FromBody] CustomerLocationDTO customerLocationDTO)
        {
            return CustomerService.SearchCustomerLoc(customerLocationDTO);
        }
    }
}
