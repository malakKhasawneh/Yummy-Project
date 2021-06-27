using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IRoleServices
    {
        Role Create(Role role);
        List<Role> GetAll();
        Role Update(Role role);
        Role Delete(int id);
    }
}
