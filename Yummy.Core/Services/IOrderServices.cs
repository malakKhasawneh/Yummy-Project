using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Services
{
    public interface IOrderServices
    {
        public Order Create(Order order);
        public List<Order> GetAll();
        public Order Update(Order order);
        public Order Delete(int id);
        List<Order> DailyOrderReport(DailyReportDTO dailyReportDTO);

    }
}
