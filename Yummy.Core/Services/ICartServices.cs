using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface ICartServices
    {
        Cart Create(Cart cart);
        List<Cart> GetAll();
        Cart Update(Cart cart);
        Cart Delete(int id);
        Cart GetByCustomerID(int id);
    }
}
