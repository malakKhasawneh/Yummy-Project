using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Meal
    {
        [Key]
        public int MealID { get; set; }
        public int Quantity_ { get; set; }
        public string MealName { get; set; }
        public float Price { get; set; }
        public string description_ { get; set; }
        public int MenuID { get; set; }
        [ForeignKey("MenuID")]
        public virtual Menu Menu { get; set; }
        public string MealImg { get; set; }

        public ICollection<Order_Meal> Order_Meals { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
