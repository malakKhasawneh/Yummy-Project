using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Repository
{
    public interface IMenuRepository
    {
        int Create(Menu Data);
        List<Menu> GetAll();
        int Update(Menu Data);
        int Delete(int id);
        List<Menu> SearchMenu(MenuDTO menuDTO);

    }
}
