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
   public class OfferRepository : IOfferRepository
    {
        private readonly IDBContext DBContext;
        public OfferRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public int Create(Offer Data)
        {
            var p = new DynamicParameters();
            p.Add("@validity", Data.Validity, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@discountAmonut", Data.DiscountAmonut_, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@mealID", Data.MealID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertOffer", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public List<Offer> GetAll()
        {
            IEnumerable<Offer> result = DBContext.Connection.Query<Offer>("GetAllOffer", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public int Update(Offer Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.OfferID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@validity", Data.Validity, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("@discountAmonut", Data.DiscountAmonut_, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@mealID", Data.MealID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdateOffer", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteOffer", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
