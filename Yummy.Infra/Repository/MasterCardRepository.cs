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
    public class MasterCardRepository : IMasterCardRepository
    {
        private readonly IDBContext DBContext;
        public MasterCardRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }
        public int Create(MasterCard Data)
        {
            var p = new DynamicParameters();
            p.Add("@cardNumber", Data.CardNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cardVerfi", Data.CardVerfi, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@expireDate", Data.ExpireDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertMasterCard", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public List<MasterCard> GetAll()
        {
            IEnumerable<MasterCard> result = DBContext.Connection.Query<MasterCard>("GetAllMasterCard", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public int Update(MasterCard Data)
        {
            var p = new DynamicParameters();
            p.Add("@MasterCardId", Data.MasterCardID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cardNumber", Data.CardNumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@cardVerfi", Data.CardVerfi, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@expireDate", Data.ExpireDate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = DBContext.Connection.ExecuteAsync("UpdateMasterCard", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@MasterCardId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteMasterCard", p, commandType: CommandType.StoredProcedure);
            return 1;
        }
    }
}
