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
    public  class CartRepository : ICartRepository
    {
        private readonly IDBContext DBContext;
        public CartRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Cart Data)
        {
            var p = new DynamicParameters();
            p.Add("@OrderId", Data.OrderID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CustomerId", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PaymentId", Data.PaymentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertCart", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Cart> GetAll()
        {
            IEnumerable<Cart> result = DBContext.Connection.Query<Cart>("GetAllCart", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public Cart GetByCustomerID(int id )
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            Cart result = DBContext.Connection.QueryFirst<Cart>("GetCartByCustomerId",p, commandType: CommandType.StoredProcedure);
            return result;

        }


        public int Update(Cart Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.CartID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@OrderId", Data.OrderID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CustomerId", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@PaymentId", Data.PaymentID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateCart", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteCart", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

    }
}
