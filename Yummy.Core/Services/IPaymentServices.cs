using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;

namespace Yummy.Core.Services
{
    public interface IPaymentServices
    {
        Payment Create(Payment payment);
        List<Payment> GetAll();
        Payment Update(Payment payment);
        Payment Delete(int id);
    }
}
