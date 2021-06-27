using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IMasterCardServices
    {
        MasterCard Create(MasterCard masterCard);
        List<MasterCard> GetAll();
        MasterCard Update(MasterCard masterCard);
        MasterCard Delete(int id);
    }
}
