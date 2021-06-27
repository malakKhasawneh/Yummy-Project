using Microsoft.AspNetCore.Authorization;
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
    public class CartController : Controller
    {

        private readonly ICartServices CartService;
        public CartController(ICartServices employeeServices)
        {
            CartService = employeeServices;
        }
        [Authorize("Customer")]
        [HttpPost]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status400BadRequest)]
        public Cart Create([FromBody] Cart cart)
        {
            return CartService.Create(cart);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        public List<Cart> GetAll()
        {
            return CartService.GetAll();
        }

        [Authorize("Customer")]
        [HttpPut]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status400BadRequest)]
        public Cart Update([FromBody] Cart cart)
        {
            return CartService.Update(cart);
        }
        [Authorize("Customer")]
        [HttpDelete("{id}")]
        public Cart Delete(int id)
        {
            return CartService.Delete(id);

        }
        [HttpGet]
        [Route("CustomerId/{id}")]
        public Cart GetByCustomerId(int id)
        {
            return CartService.GetByCustomerID(id);

        }
    }
}
