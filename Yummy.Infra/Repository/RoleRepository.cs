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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDBContext DBContext;
        public RoleRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Role Data)
        {
            var p = new DynamicParameters();
            p.Add("@Name", Data.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("InsertRole", p, commandType: CommandType.StoredProcedure);
            return 1;

        }


        public List<Role> GetAll()
        {
            IEnumerable<Role> result = DBContext.Connection.Query<Role>("GetAllRoles", commandType: CommandType.StoredProcedure);
            return result.ToList();
           
        }


        public int Update(Role Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@RoleName", Data.RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateRole", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteRole", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

    }
}
