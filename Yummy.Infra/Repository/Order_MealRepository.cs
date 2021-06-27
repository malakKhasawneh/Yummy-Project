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
    public class Order_MealRepository: IOrder_MealRepository
    {
        private readonly IDBContext DBContext;
        public Order_MealRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public int Create(Order_Meal Data)
        {
            var p = new DynamicParameters();
            p.Add("@orderID", Data.OrderID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mealID", Data.MealID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertOrderMeal", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public List<Order_Meal> GetAll()
        {
            IEnumerable<Order_Meal> result = DBContext.Connection.Query<Order_Meal>("GetAllOrderMeal", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public int Update(Order_Meal Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.OrderMealID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@orderID", Data.OrderID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mealID", Data.MealID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateOrderMeal", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteOrderMeal", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
