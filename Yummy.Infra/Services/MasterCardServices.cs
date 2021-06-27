using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class MasterCardServices: IMasterCardServices
    {
        private readonly IMasterCardRepository MasterCardRepository;
        public MasterCardServices(IMasterCardRepository masterCardRepository)
        {
            MasterCardRepository = masterCardRepository;
        }
        public MasterCard Create(MasterCard masterCard)
        {
            MasterCardRepository.Create(masterCard);
            return new MasterCard();
        }

        public List<MasterCard> GetAll()
        {
            return MasterCardRepository.GetAll();
        }

        public MasterCard Update(MasterCard masterCard)
        {
            MasterCardRepository.Update(masterCard);
            return new MasterCard();
        }

        public MasterCard Delete(int id)
        {
            MasterCardRepository.Delete(id);
            return new MasterCard();
        }
    }
}
