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
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IDBContext DBContext;
        public RestaurantRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Restaurant Data)
        {
            var p = new DynamicParameters();
            p.Add("@RestName", Data.RestaurantName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Location", Data.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Stauts", Data.Stauts, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cuisines", Data.Cuisines, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@phone", Data.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RestCategID", Data.RestaurantCategoryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertRestaurant", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Restaurant> GetAll()
        {
            IEnumerable<Restaurant> result = DBContext.Connection.Query<Restaurant>("GetAllRestaurant", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        public int Update(Restaurant Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RestName", Data.RestaurantName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Location", Data.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@stauts", Data.Stauts, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@cuisines", Data.Cuisines, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@phone", Data.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RestCategID", Data.RestaurantCategoryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateRestaurant", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteRestaurant", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public List<Restaurant> SearchRestaurant(RestaurantDTO restaurantDTO)
        {
            var p = new DynamicParameters();
            p.Add("@Category", restaurantDTO.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@avgrate", restaurantDTO.AverageRate, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@location", restaurantDTO.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RestCategory", restaurantDTO.RestCategory, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<Restaurant> result = DBContext.Connection.Query<Restaurant>("SearchResturent", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    }
}
