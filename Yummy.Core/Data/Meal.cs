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

        [Required(ErrorMessage = "Quantity is required")]
        [Display(Name = "Quantity")]
        public int Quantity_ { get; set; }

        [Required(ErrorMessage = "Meal Name is required")]
        [Display(Name = "Meal Name")]
        [StringLength(50)]
        public string MealName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public float Price { get; set; }

        [Required(ErrorMessage = "description is required")]
        [Display(Name = "description")]
        [StringLength(50)]
        public string description_ { get; set; }

      
        [Display(Name = "Menu")]
        public int MenuID { get; set; }
        [ForeignKey("MenuID")]
        public virtual Menu Menu { get; set; }
        public string MealImg { get; set; }

        public ICollection<Order_Meal> Order_Meals { get; set; }
        public ICollection<Offer> Offers { get; set; }
    }
}
