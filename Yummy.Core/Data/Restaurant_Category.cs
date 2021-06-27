using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yummy.Core.Data
{
    public class Restaurant_Category
    {
        [Key]
        public int RestCategoryID{ get; set; }
        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category { get; set; }

        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
