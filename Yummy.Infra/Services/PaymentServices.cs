using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IPaymentRepository PaymentRepository;
        public PaymentServices(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }

        public Payment Create(Payment payment)
        {
            PaymentRepository.Create(payment);
            return new Payment();
        }


        public List<Payment> GetAll()
        {
            return PaymentRepository.GetAll();
        }
        public Payment Update(Payment payment)
        {
            PaymentRepository.Update(payment);
            return new Payment();
        }
        public Payment Delete(int id)
        {
            PaymentRepository.Delete(id);
            return new Payment();
        }
    }
}
