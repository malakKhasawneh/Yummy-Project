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
    public class RestaurantEmployeeRepository : IRestaurantEmployeeRepository
    {

        private readonly IDBContext DBContext;
        public RestaurantEmployeeRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Restaurant_Employee Data)
        {
            var p = new DynamicParameters();
            p.Add("@RestId", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@EmpId", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("InsertRestaurantEmployee", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public int Update(Restaurant_Employee Data)
        {
            var p = new DynamicParameters();
            p.Add("@RestEmpId", Data.RestaurantEmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RestId", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@EmpId", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateRestaurantEmployee", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteRestaurantEmployee", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
