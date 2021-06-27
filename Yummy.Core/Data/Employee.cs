using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [StringLength(50, MinimumLength = 5)]
        public string UserName { get; set; }
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [StringLength(50)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public float Salary { get; set; }
        public string EmpImg { get; set; }

        [Display(Name = "Role Name")]
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        public ICollection<Restaurant_Employee> restaurant_Employees { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Testimonial> Testimonials { get; set; }

    }


}
