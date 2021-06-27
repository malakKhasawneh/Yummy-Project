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
    public class RestaurantCategoryController : Controller
    {
        private readonly IRestaurantCategoryServices RestaurantCategortService;
        public RestaurantCategoryController(IRestaurantCategoryServices RestServices)
        {
            RestaurantCategortService = RestServices;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Restaurant_Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Restaurant_Category), StatusCodes.Status400BadRequest)]
        public Restaurant_Category Create([FromBody] Restaurant_Category book)
        {
            return RestaurantCategortService.Create(book);
        }
        [Authorize("Admin")]
        [Authorize("Customer")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Restaurant_Category>), StatusCodes.Status200OK)]
        public List<Restaurant_Category> GetAll()
        {
            return RestaurantCategortService.GetAll();
        }
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Restaurant_Category), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Restaurant_Category), StatusCodes.Status400BadRequest)]
        public Restaurant_Category Update([FromBody] Restaurant_Category book)
        {
            return RestaurantCategortService.Update(book);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Restaurant_Category Delete(int id)
        {
            return RestaurantCategortService.Delete(id);

        }
    }
}
