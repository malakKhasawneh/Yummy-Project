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
    public class ReviewRepository : IReviewRepository
    {
        private readonly IDBContext DBContext;
        public ReviewRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Review Data)
        {
            var p = new DynamicParameters();
            p.Add("@rate", Data.Rate, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@restaurantID", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertReview", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Review> GetAll()
        {
            IEnumerable<Review> result = DBContext.Connection.Query<Review>("GetAllReview", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public int Update(Review Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.ReviewID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@rate", Data.Rate, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@customerID", Data.CustomerID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@restaurantID", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdateReview", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteReview", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
