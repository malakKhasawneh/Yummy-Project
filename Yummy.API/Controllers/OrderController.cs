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
    public class OrderController : Controller
    {
        private readonly IOrderServices orderServices;
        public OrderController(IOrderServices orderService)
        {
            orderServices = orderService;
        }
        [Authorize("Customer")]
        [HttpPost]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Order), StatusCodes.Status400BadRequest)]
        public Order Create([FromBody] Order order)
        {
            return orderServices.Create(order);
        }
        [Authorize("Admin")]
        [Authorize("Delivery")] // we should crate proc to check for deliver id that login to the system an display his orders 
        [HttpGet]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
        public List<Order> GetAll()
        {
            return orderServices.GetAll();
        }
        [HttpPut]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Order), StatusCodes.Status400BadRequest)]
        public Order Update([FromBody] Order order)
        {
            return orderServices.Update(order);
        }
        [Authorize("Customer")]
        [HttpDelete("{id}")]
        public Order Delete(int id)
        {
            return orderServices.Delete(id);

        }
        [Authorize("Accountant")]
        [Authorize("Admin")]
        [HttpPost]
        [Route("ReportMenu")]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status400BadRequest)]
        public List<Order> DailyReport([FromBody] DailyReportDTO dailyReportDTO)
        {
            return orderServices.DailyOrderReport(dailyReportDTO);
              
        }
    }
}
