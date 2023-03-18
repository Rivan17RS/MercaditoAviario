using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Offer
    {
        public Offer() 
        {
            Status = "Disponible";
        }
        public string Id { get; set; }
        public string SubscriptorId { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }

        public Subscriptor Subscriptor { get; set; }

        public Subscriptor BuyerSubscriptor { get; set; }
    }
}
