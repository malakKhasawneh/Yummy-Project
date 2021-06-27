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
    public class TestimonialController : Controller
    {
        private readonly ITestimonialServices TestimonialService;
        public TestimonialController(ITestimonialServices testimonialService)
        {
            TestimonialService = testimonialService;
        }
        [Authorize("Customer")]
        [HttpPost]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status400BadRequest)]
        public Testimonial Create([FromBody] Testimonial testimonial)
        {
            return TestimonialService.Create(testimonial);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Testimonial>), StatusCodes.Status200OK)]
        public List<Testimonial> GetAll()
        {
            return TestimonialService.GetAll();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Testimonial), StatusCodes.Status400BadRequest)]
        public Testimonial Update([FromBody] Testimonial book)
        {
            return TestimonialService.Update(book);
        }

        [HttpDelete("{id}")]
        public Testimonial Delete(int id)
        {
            return TestimonialService.Delete(id);

        }
    }
}
