using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class Offer
    {
        [Key]
        public int OfferID { get; set; }
        public DateTime Validity { get; set; }
        public float DiscountAmonut_ { get; set; }
        public int MealID { get; set; }
        [ForeignKey("MealID")]
        public virtual Meal Meal { get; set; }

        public ICollection<MasterCard> MasterCards { get; set; }
    }
}
