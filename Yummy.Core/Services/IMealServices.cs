using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IMealServices
    {
        Meal Create(Meal meal);
        List<Meal> GetAll();
        Meal Update(Meal meal);
        Meal Delete(int id);
    }
}
