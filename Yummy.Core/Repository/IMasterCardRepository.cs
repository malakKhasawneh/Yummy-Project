using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IMasterCardRepository
    {
        int Create(MasterCard Data);
        List<MasterCard> GetAll();
        int Update(MasterCard Data);
        int Delete(int id);
    }
}
