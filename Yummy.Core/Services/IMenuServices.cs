using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.DTO;

namespace Yummy.Core.Services
{
    public interface IMenuServices
    {
        Menu Create(Menu menu);
        List<Menu> GetAll();
        Menu Update(Menu menu);
        Menu Delete(int id);
        List<Menu> SearchMenu(MenuDTO menuDTO);

    }
}
