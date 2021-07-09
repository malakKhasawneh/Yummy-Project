using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }

        [Required(ErrorMessage = "Feed back is required")]
        [Display(Name = "Feed back")]
        [StringLength(80)]
        public string Feedback { get; set; }

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status Method")]
        [StringLength(50)]
        public string Status_ { get; set; }

        [Display(Name = "Restaurant Name")]
        public int RestaurantID { get; set; }
        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }

        [Display(Name = "Employee Name")]
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

        [Display(Name = "Customer Name")]
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }


    }
}
