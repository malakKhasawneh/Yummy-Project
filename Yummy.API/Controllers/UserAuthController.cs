using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummy.Core.Data;
using Yummy.Core.Services;

namespace Yummy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : Controller
    {
        
        private readonly IJwtUserAuthService JwtUserAuthService;
        public UserAuthController(IJwtUserAuthService jwtUserAuthService)
        {
            JwtUserAuthService = jwtUserAuthService;
        }
        [HttpPost]
        [Route("EmployeeAuthenticate")]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Employee), StatusCodes.Status400BadRequest)]
        public IActionResult EmployeeAuthenticate([FromBody] Employee employee)
        {
            var token = JwtUserAuthService.EmployeeAuthenticate(employee);
            if (token == null)
                return Unauthorized();
            else
                return Ok(token);
        }

        [HttpPost]
        [Route("CustomerAuthenticate")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status400BadRequest)]
        public IActionResult CustomerAuthenticate([FromBody] Customer customer)
        {
            var token = JwtUserAuthService.CustomerAuthenticate(customer);
            if (token == null)
                return Unauthorized();
            else
                return Ok(token);
        }


    }
}
