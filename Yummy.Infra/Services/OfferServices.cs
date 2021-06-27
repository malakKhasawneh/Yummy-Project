using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class OfferServices : IOfferServices
    {
        private readonly IOfferRepository OfferRepository;
        public OfferServices(IOfferRepository offerRepository)
        {
            OfferRepository = offerRepository;
        }

        public Offer Create(Offer offer)
        {
            OfferRepository.Create(offer);
            return new Offer();
        }

        public List<Offer> GetAll()
        {
            return OfferRepository.GetAll();
        }

        public Offer Update(Offer offer)
        {
            OfferRepository.Update(offer);
            return new Offer();
        }

        public Offer Delete(int id)
        {
            OfferRepository.Delete(id);
            return new Offer();
        }
    }
}
