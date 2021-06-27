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
    public class ReviewController : Controller
    {
        private readonly IReviewServices ReviewService;
        public ReviewController(IReviewServices reviewService)
        {
            ReviewService = reviewService;
        }
        [Authorize("Customer")]
        [HttpPost]
        [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Review), StatusCodes.Status400BadRequest)]
        public Review Create([FromBody] Review review)
        {
            return ReviewService.Create(review);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Review>), StatusCodes.Status200OK)]
        public List<Review> GetAll()
        {
            return ReviewService.GetAll();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Review), StatusCodes.Status400BadRequest)]
        public Review Update([FromBody] Review review)
        {
            return ReviewService.Update(review);
        }

        [HttpDelete("{id}")]
        public Review Delete(int id)
        {
            return ReviewService.Delete(id);

        }
    }
}
