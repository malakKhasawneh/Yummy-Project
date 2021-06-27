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
    public class MealController : Controller
    {
        private readonly IMealServices MealService;
        public MealController(IMealServices mealService)
        {
            MealService = mealService;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Meal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Meal), StatusCodes.Status400BadRequest)]
        public Meal Create([FromBody] Meal meal)
        {
            return MealService.Create(meal);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Meal>), StatusCodes.Status200OK)]
        public List<Meal> GetAll()
        {
            return MealService.GetAll();
        }
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Meal), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Meal), StatusCodes.Status400BadRequest)]
        public Meal Update([FromBody] Meal meal)
        {
            return MealService.Update(meal);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Meal Delete(int id)
        {
            return MealService.Delete(id);

        }
    }
}
