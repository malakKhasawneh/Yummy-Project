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
    public class RestaurantController : Controller
    {
        private readonly IRestaurantServices RestaurantService;
        public RestaurantController(IRestaurantServices RestServices)
        {
            RestaurantService = RestServices;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status400BadRequest)]
        public Restaurant Create([FromBody] Restaurant book)
        {
            return RestaurantService.Create(book);
        }
        [Authorize("Admin")]
        [Authorize("Customer")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Restaurant>), StatusCodes.Status200OK)]
        public List<Restaurant> GetAll()
        {
            return RestaurantService.GetAll();
        }
        [Authorize("Admin")]

        [HttpPut]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Restaurant), StatusCodes.Status400BadRequest)]
        public Restaurant Update([FromBody] Restaurant book)
        {
            return RestaurantService.Update(book);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Restaurant Delete(int id)
        {
            return RestaurantService.Delete(id);

        }
        [Authorize("Customer")]
        [HttpPost]
        [Route("RestaurantSearch")]
        [ProducesResponseType(typeof(List<Restaurant>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Restaurant>), StatusCodes.Status400BadRequest)]
        public List<Restaurant> SearchRestaurant([FromBody] RestaurantDTO restaurantDTO)
        {
            return RestaurantService.SearchRestaurant(restaurantDTO);

        }
    }
}
