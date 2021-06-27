using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IOfferRepository
    {
        int Create(Offer Data);
        List<Offer> GetAll();
        int Update(Offer Data);
        int Delete(int id);
    }
}
