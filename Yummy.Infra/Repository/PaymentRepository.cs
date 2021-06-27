using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yummy.Core.Common;
using Yummy.Core.Data;
using Yummy.Core.Repository;

namespace Yummy.Infra.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDBContext DBContext;
        public PaymentRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Payment Data)
        {
            var p = new DynamicParameters();
            p.Add("@amount", Data.Amount, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@paymentMethod", Data.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@masterCardId", Data.MasterCardID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertPayment", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Payment> GetAll()
        {
            IEnumerable<Payment> result = DBContext.Connection.Query<Payment>("GetAllPayment", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int Update(Payment Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.PaymentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@amount", Data.Amount, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@paymentMethod", Data.PaymentMethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@masterCardId", Data.MasterCardID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdatePayment", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeletePayment", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
