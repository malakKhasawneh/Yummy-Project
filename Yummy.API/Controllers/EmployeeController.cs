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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices EmployeeService;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            EmployeeService = employeeServices;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status400BadRequest)]
        public Employee Create([FromBody] Employee book)
        {
            return EmployeeService.Create(book);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), StatusCodes.Status200OK)]
        public List<Employee> GetAll()
        {
            return EmployeeService.GetAll();
        }
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status400BadRequest)]
        public Employee Update([FromBody] Employee book)
        {
            return EmployeeService.Update(book);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Employee Delete(int id)
        {
            return EmployeeService.Delete(id);

        }
        [HttpPost]
        [Route("check")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public object UserAvailability([FromBody] UserAvailabilityDTO userAvailabilityDTO)
        {
            return EmployeeService.UserAvailability(userAvailabilityDTO);
        }
        [HttpGet]
        [Route("GetAllOrder/{id}")]
        [ProducesResponseType(typeof(List<Customer>), StatusCodes.Status200OK)]

        public List<object> GetAllOrder(int id)
        {
            return  EmployeeService.GetAllOrder(id);
        }
    }
}
