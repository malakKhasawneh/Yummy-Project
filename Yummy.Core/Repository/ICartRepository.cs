using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface ICartRepository
    {
        int Create(Cart Data);
        List<Cart> GetAll();
        int Update(Cart Data);
        int Delete(int id);
        Cart GetByCustomerID(int id);


    }
}
