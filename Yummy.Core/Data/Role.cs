using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Yummy.Core.Data
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        [StringLength(50)]
        public string RoleName { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
