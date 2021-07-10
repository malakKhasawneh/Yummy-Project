using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Order Date is required")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Total is required")]
        public float Total { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [Display(Name = "Payment ID")]
        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual Payment Payment { get; set; }

        [Display(Name = "Employee Name")]
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        public ICollection<Order_Meal> Order_Meals { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
