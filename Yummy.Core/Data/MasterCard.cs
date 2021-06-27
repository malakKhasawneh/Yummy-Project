using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Yummy.Core.Data
{
    public class MasterCard
    {
        [Key]
        public int MasterCardID { get; set; }
        public int CardNumber { get; set; }
        public int CardVerfi { get; set; }
        public DateTime ExpireDate { get; set; }
        public object OfferID { get; set; }
        [ForeignKey("OfferID")]
        public virtual Offer Offer { get; set; }

        public ICollection<Payment> Payments { get; set; }

    }
}
