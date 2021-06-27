using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IMealRepository
    {
        int Create(Meal Data);
        List<Meal> GetAll();
        int Update(Meal Data);
        int Delete(int id);
    }
}
