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
    public class OfferController : Controller
    {
        private readonly IOfferServices OfferService;
        public OfferController(IOfferServices offerService)
        {
            OfferService = offerService;
        }
        [Authorize("Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(Offer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Offer), StatusCodes.Status400BadRequest)]
        public Offer Create([FromBody] Offer offer)
        {
            return OfferService.Create(offer);
        }
        [Authorize("Customer")]
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Offer>), StatusCodes.Status200OK)]
        public List<Offer> GetAll()
        {
            return OfferService.GetAll();
        }
        [Authorize("Admin")]
        [HttpPut]
        [ProducesResponseType(typeof(Offer), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Offer), StatusCodes.Status400BadRequest)]
        public Offer Update([FromBody] Offer offer)
        {
            return OfferService.Update(offer);
        }
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public Offer Delete(int id)
        {
            return OfferService.Delete(id);

        }
    }
}
