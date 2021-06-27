using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category_ { get; set; }

        [Display(Name = "Restaurant Name")]
        public int RestaurantID { get; set; }
        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
