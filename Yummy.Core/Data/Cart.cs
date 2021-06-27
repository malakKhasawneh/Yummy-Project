using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }


        [Display(Name = "Customer")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }


        [Display(Name = "Payemnt")]
        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual Payment Payment { get; set; }

        //public ICollection<Cart> carts { get; set; } set this sentence in payment and order and customer class
        

    }
}
