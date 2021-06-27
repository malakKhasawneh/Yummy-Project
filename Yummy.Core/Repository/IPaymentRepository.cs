using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Repository
{
    public interface IPaymentRepository
    {
        int Create(Payment Data);
        List<Payment> GetAll();
        int Update(Payment Data);
        int Delete(int id);
    }
}
