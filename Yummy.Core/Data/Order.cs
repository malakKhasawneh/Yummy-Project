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
        public DateTime OrderDate { get; set; }
        public float Total { get; set; }
        public string Status { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public int PaymentID { get; set; }
        [ForeignKey("PaymentID")]
        public virtual Payment Payment { get; set; }
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        public ICollection<Order_Meal> Order_Meals { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}
