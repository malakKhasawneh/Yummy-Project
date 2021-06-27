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
    public class MealRepository : IMealRepository
    {
        private readonly IDBContext DBContext;
        public MealRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public int Create(Meal Data)
        {
            var p = new DynamicParameters();
            p.Add("@quantity", Data.Quantity_, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mealName", Data.MealName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@price", Data.Price, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@description", Data.description_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@menuID", Data.MenuID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mealImg", Data.MealImg, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("InsertMeal", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Meal> GetAll()
        {
            IEnumerable<Meal> result = DBContext.Connection.Query<Meal>("GetAllMeal", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int Update(Meal Data)
        {

            var p = new DynamicParameters();
            p.Add("@Id", Data.MealID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@quantity", Data.Quantity_, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mealName", Data.MealName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@price", Data.Price, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@description", Data.description_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@menuID", Data.MenuID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@mealImg", Data.MealImg, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdateMeal", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteMeal", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
