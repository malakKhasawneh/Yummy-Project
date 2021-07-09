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
        [Required(ErrorMessage = "Amount is required")]
        public float Amount { get; set; }

        [Display(Name = "Payment Method")]
        [Required(ErrorMessage = "Payment Method is required")]
        [StringLength(50)]
        public string PaymentMethod { get; set; }

        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Master Card")]
        public int MasterCardID { get; set; }
        [ForeignKey("MasterCardID")]
        public virtual MasterCard MasterCard { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
