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
   public class TestimonialRepository : ITestimonialRepository
    {
        private readonly IDBContext DBContext;
        public TestimonialRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Testimonial Data)
        {
            var p = new DynamicParameters();
            p.Add("@feedback", Data.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@status", Data.Status_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@restaurantID", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@employeeID", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertTestimonial", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Testimonial> GetAll()
        {
            IEnumerable<Testimonial> result = DBContext.Connection.Query<Testimonial>("GetAllTestimonial", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int Update(Testimonial Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.TestimonialID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@feedback", Data.Feedback, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@status", Data.Status_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@restaurantID", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@employeeID", Data.EmployeeID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteTestimonial", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
