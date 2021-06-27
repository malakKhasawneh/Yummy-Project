using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public float Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public int MasterCardID { get; set; }
        [ForeignKey("MasterCardID")]
        public virtual MasterCard MasterCard { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
