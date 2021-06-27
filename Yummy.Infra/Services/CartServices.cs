using System;
using System.Collections.Generic;
using System.Text;
using Yummy.Core.Data;
using Yummy.Core.Repository;
using Yummy.Core.Services;

namespace Yummy.Infra.Services
{
    public class CartServices: ICartServices
    {
        private readonly ICartRepository CartRepository;
        public CartServices(ICartRepository cartRepository)
        {
            CartRepository = cartRepository;
        }

        public Cart Create(Cart cart)
        {
            CartRepository.Create(cart);
            return new Cart();
        }

        public List<Cart> GetAll()
        {
            return CartRepository.GetAll();

        }

        public Cart Update(Cart cart)
        {
            CartRepository.Update(cart);
            return cart;
        }

        public Cart Delete(int id)
        {
            CartRepository.Delete(id);
            return new Cart();
        }
        public Cart GetByCustomerID(int id)
        {
            return CartRepository.GetByCustomerID(id);
        }

    }
}
