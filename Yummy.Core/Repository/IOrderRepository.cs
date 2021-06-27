using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Repository
{
    public interface IOrderRepository
    {
        int Create(Order Data);
        List<Order> GetAll();
        int Update(Order Data);
        int Delete(int id);
        List<Order> DailyOrderReport(DailyReportDTO dailyReportDTO);
    }
}
