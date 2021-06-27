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
        public string Feedback { get; set; }
        public string Status_ { get; set; }
        public int RestaurantID { get; set; }
        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }


    }
}
