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
    public class PaymentController : Controller
    {
        private readonly IPaymentServices PaymentService;
        public PaymentController(IPaymentServices paymentService)
        {
            PaymentService = paymentService;
        }
        [Authorize("Customer")] 
        [HttpPost]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status400BadRequest)]
        public Payment Create([FromBody] Payment payment)
        {
            return PaymentService.Create(payment);
        }
        [Authorize("Admin")]
        [HttpGet]
        [ProducesResponseType(typeof(List<Payment>), StatusCodes.Status200OK)]
        public List<Payment> GetAll()
        {
            return PaymentService.GetAll();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Payment), StatusCodes.Status400BadRequest)]
        public Payment Update([FromBody] Payment payment)
        {
            return PaymentService.Update(payment);
        }

        [HttpDelete("{id}")]
        public Payment Delete(int id)
        {
            return PaymentService.Delete(id);

        }
    }
}
