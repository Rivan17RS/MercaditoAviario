using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseOrder:BaseEntity
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string CompanyName { get; set; }
        public string BuyerPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Take this off in the case it fails--
        public Offer OfferId { get; set; }
        public Subscriptor SubscriptorId { get; set;}

        //Take this off in the case it fails ^
    }
}
