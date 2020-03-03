using System;
using System.ComponentModel.DataAnnotations;

namespace Lekarna.ViewModels.Offers
{
    public class CreateOfferInputModel
    {
        [Required]
        public string Offer { get; set; } 

        [Required(ErrorMessage = "Please fill medicine!")]
        
        public string Medicine { get; set; }

        [Required]
        [Display(Name = "Price Without VAT")]
        public decimal PriceWithoutVAT { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public int Orders { get; set; }

        [Required]
        public decimal VAT { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Order Date")]
        public DateTime OrderDate { get; set; } 

        [Required]
        [Display(Name = "Order Type")]
        public OrderType OrderType { get; set; }
}

    public enum OrderType
    {
        Normal = 1,
        Fast = 2,
        Express = 3,
    }
}
