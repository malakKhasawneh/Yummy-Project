using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Restaurant_Employee
    {
        [Key]
        public int RestaurantEmployeeID { get; set; }

        [Display(Name = "Restaurant Name ")]
        public int RestaurantID { get; set; }
        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }


        [Display(Name = "Employee Name")]
        public int EmployeeID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }

    }
}
