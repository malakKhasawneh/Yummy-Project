using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Order_Meal
    {
        public int OrderMealID { get; set; }

        [Display(Name = "Order")]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { get; set; }

        [Display(Name = "Meal")]
        public int MealID { get; set; }
        [ForeignKey("MealID")]
        public virtual Meal Meal { get; set; }
    }
}
