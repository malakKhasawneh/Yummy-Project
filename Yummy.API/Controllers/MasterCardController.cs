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
    public class MasterCardController : Controller
    {
        private readonly IMasterCardServices MasterCardService;
        public MasterCardController(IMasterCardServices masterCardService)
        {
            MasterCardService = masterCardService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MasterCard), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MasterCard), StatusCodes.Status400BadRequest)]
        public MasterCard Create([FromBody] MasterCard masterCard)
        {
            return MasterCardService.Create(masterCard);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<MasterCard>), StatusCodes.Status200OK)]
        public List<MasterCard> GetAll()
        {
            return MasterCardService.GetAll();
        }

        [HttpPut]
        [ProducesResponseType(typeof(MasterCard), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MasterCard), StatusCodes.Status400BadRequest)]
        public MasterCard Update([FromBody] MasterCard masterCard)
        {
            return MasterCardService.Update(masterCard);
        }

        [HttpDelete("{id}")]
        public MasterCard Delete(int id)
        {
            return MasterCardService.Delete(id);

        }
    }
}
