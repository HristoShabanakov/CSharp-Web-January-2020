using System;

namespace Lekarna.Models
{
    public class Offer
    {
        public string Id { get; set; }

        public string Product { get; set; }

        public int Miligrams { get; set; }

        public int Pills { get; set; }  

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime OfferTermination { get; set; }

        public decimal PriceWithoutVAT { get; set; }

        //Calculated property
        public decimal PriceWithVAT { get; set; } 
    }
}
