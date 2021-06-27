using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        [Required(ErrorMessage = "Restaurant Name is required")]
        [StringLength(50)]
        public string RestaurantName { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [StringLength(50)]
        public string Location { get; set; }
        public string Stauts { get; set; }
        [Required(ErrorMessage = "Cuisines is required")]
        [StringLength(50)]
        public string Cuisines { get; set; }
        public float AvgRate { get; set; }
        public string PhoneNumber { get; set; }

        [Display(Name = "Restaurant Category")]
        public int RestaurantCategoryID { get; set; }
        [ForeignKey("RestaurantCategoryID")]
        public virtual Restaurant_Category Restaurant_Category { get; set; }
        public ICollection<Menu> Menus { get; set; }
        public ICollection<Restaurant_Employee> Restaurant_Employees { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }



    }
}
