using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yummy.Core.Common;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;
using Yummy.Infra.Common;

namespace Yummy.Infra.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDBContext DBContext;
        public OrderRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Order Data)
        {
            var p = new DynamicParameters();
            p.Add("@date", Data.OrderDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@total", Data.Total, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@status", Data.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@paymentID", Data.PaymentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@employeeID", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertOrder", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Order> GetAll()
        {
            IEnumerable<Order> result = DBContext.Connection.Query<Order>("GetAllOrder", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int Update(Order Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.OrderID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@date", Data.OrderDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@total", Data.Total, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@status", Data.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@paymentID", Data.PaymentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@employeeID", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateOrder", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteOrder", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        
        public List<Order> DailyOrderReport(DailyReportDTO dailyReportDTO)
        {
            var p = new DynamicParameters();
            p.Add("@Date", dailyReportDTO.Date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateFrom", dailyReportDTO.DateFrom, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@DateTo", dailyReportDTO.DateTo, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            IEnumerable<Order> result = DBContext.Connection.Query<Order>("DailyReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
    }
}
