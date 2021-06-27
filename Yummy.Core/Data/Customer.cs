using System;
using System.Collections.Generic;
using System.Text;

namespace Yummy.Core.Data
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string img { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
