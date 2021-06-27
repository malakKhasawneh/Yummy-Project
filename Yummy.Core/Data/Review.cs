using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int Rate { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public int RestaurantID { get; set; }
        [ForeignKey("RestaurantID")]
        public virtual Restaurant Restaurant { get; set; }

    }
}
