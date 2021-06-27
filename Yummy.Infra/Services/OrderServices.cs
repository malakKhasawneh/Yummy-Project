using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository OrderRepository;
        public OrderServices(IOrderRepository orderRepository)
        {
            OrderRepository = orderRepository;
        }

        public Order Create(Order order)
        {
            OrderRepository.Create(order);
            return new Order();
        }


        public List<Order> GetAll()
        {
            return OrderRepository.GetAll();
        }
        public Order Update(Order order)
        {
            OrderRepository.Update(order);
            return new Order();
        }
        public Order Delete(int id)
        {
            OrderRepository.Delete(id);
            return new Order();
        }
        public List<Order> DailyOrderReport(DailyReportDTO dailyReportDTO)
        {
            return OrderRepository.DailyOrderReport(dailyReportDTO);
        }

    }
}
