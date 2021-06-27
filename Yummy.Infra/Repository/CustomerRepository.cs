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

namespace Yummy.Infra.Repository
{
   public class CustomerRepository : ICustomerRepository
    {
        private readonly IDBContext DBContext;
        public CustomerRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Customer Data)
        {
            var p = new DynamicParameters();
            p.Add("@name", Data.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserName", Data.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pass", Data.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Age", Data.age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@gender", Data.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@email", Data.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Img", Data.img, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@location", Data.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@phone", Data.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertCustomer", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Customer> GetAll()
        {
            IEnumerable<Customer> result = DBContext.Connection.Query<Customer>("GetAllCustomer", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int Update(Customer Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@name", Data.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UserName", Data.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Pass", Data.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Age", Data.age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@gender", Data.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@email", Data.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Img", Data.img, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@location", Data.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@phone", Data.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateCustomer", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteCustomer", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public object CustomerAvailability(CustomerAvailabilityDTO customerAvailabilityDTO)
        {
            var p = new DynamicParameters();
            p.Add("@UserName", customerAvailabilityDTO.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteScalar("CheckCustomerAvailability", p, commandType: CommandType.StoredProcedure);
            return result;
        }
        public List<Customer> SearchCustomerLoc(CustomerLocationDTO customerLocationDTO)
        {
            var p = new DynamicParameters();
            p.Add("@LOC", customerLocationDTO.CustomerLocation, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Customer> result = DBContext.Connection.Query<Customer>("SearchCustomerLocation", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
