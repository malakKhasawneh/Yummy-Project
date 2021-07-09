using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yummy.Core.Common;
using Yummy.Core.Data;
using Yummy.Core.DTO;
using Yummy.Core.Repository;

namespace Yummy.Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDBContext DBContext;
        public EmployeeRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Employee Data)
        {
            var p = new DynamicParameters();
            p.Add("@Name", Data.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserName", Data.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@age", Data.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@gender", Data.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@password", Data.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@email", Data.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@salary", Data.Salary, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@empImg", Data.EmpImg, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@roleID", Data.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertEmployee", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Employee> GetAll()
        {
            IEnumerable<Employee> result = DBContext.Connection.Query<Employee>("GetAllEmployee", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public  List<object> GetAllOrder(int id )
        {
            var p = new DynamicParameters();
            p.Add("@id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.Query<object>("GetDeliverId", p, commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        public int Update(Employee Data)
        {
            var p = new DynamicParameters(); 
            p.Add("@Name", Data.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Id", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UserName", Data.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@age", Data.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@gender", Data.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@password", Data.password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Email", Data.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@salary", Data.Salary, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@empIMG", Data.EmpImg, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RoleId", Data.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);

             var result = DBContext.Connection.ExecuteAsync("UpdateEmployee", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteEmployee", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

      
        public object UserAvailability(UserAvailabilityDTO userAvailabilityDTO)
        {
            var p = new DynamicParameters();
            p.Add("@UserName", userAvailabilityDTO.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteScalar("CheckUserAvailability",p, commandType: CommandType.StoredProcedure);
            return result;
        }
      

    }
}
