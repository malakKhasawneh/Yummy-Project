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
    public class RestaurantCategoryRepository : IRestaurantCategoryRepository
    {
        private readonly IDBContext DBContext;
        public RestaurantCategoryRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Restaurant_Category Data)
        {
            var p = new DynamicParameters();
            p.Add("@Category", Data.Category, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertRestaurantCategory", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Restaurant_Category> GetAll()
        {
            IEnumerable<Restaurant_Category> result = DBContext.Connection.Query<Restaurant_Category>("GetAllRestaurantCategory", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        public int Update(Restaurant_Category Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.RestCategoryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Category", Data.Category, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateRestaurantCategory", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteRestaurantCategory", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
