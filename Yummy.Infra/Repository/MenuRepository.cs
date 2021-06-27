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
    public class MenuRepository : IMenuRepository
    {
        private readonly IDBContext DBContext;
        public MenuRepository(IDBContext dbContext)
        {
            DBContext = dbContext;
        }

        public int Create(Menu Data)
        {
            var p = new DynamicParameters();
            p.Add("@Category", Data.Category_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RestId", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);

             var result = DBContext.Connection.ExecuteAsync("InsertMenu", p, commandType: CommandType.StoredProcedure);
            return 1;   

        }


        public List<Menu> GetAll()
        {
            IEnumerable<Menu> result = DBContext.Connection.Query<Menu>("GetAllMenu", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }


        public int Update(Menu Data)
        {
            var p = new DynamicParameters();
            p.Add("@Id", Data.MenuID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@Category", Data.Category_, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@RestId", Data.RestaurantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("UpdateMenu", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public int Delete(int id)
        {
            var p = new DynamicParameters();
            p.Add("@Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DBContext.Connection.ExecuteAsync("DeleteMenu", p, commandType: CommandType.StoredProcedure);
            return 1;
        }

        public List<Menu> SearchMenu(MenuDTO menuDTO)
        {
            var p = new DynamicParameters();
            p.Add("@price", menuDTO.Price, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@categoryName", menuDTO.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PriceFrom", menuDTO.PriceFrom, dbType: DbType.Single, direction: ParameterDirection.Input);
            p.Add("@PriceTo", menuDTO.PriceTo, dbType: DbType.Single, direction: ParameterDirection.Input);
            IEnumerable<Menu> result = DBContext.Connection.Query<Menu>("SearchMenu", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        
    }

}
