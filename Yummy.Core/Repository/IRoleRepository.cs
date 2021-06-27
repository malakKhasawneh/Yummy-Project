using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IRoleRepository
    {
        int Create(Role Data);
        List<Role> GetAll();
        int Update(Role Data);
        int Delete(int id);
       
      
    }
}
