using Microsoft.AspNetCore.Http;
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
        public int Quantity { get; set; } 

        [Required]
        [Display(Name = "Price Without VAT")]
        public decimal PriceWithoutVAT { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        [Display(Name = "Price With VAT")]
        public decimal PriceWithVAT { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Offer Termination")]
        public DateTime OfferTermination { get; set; } 

        public IFormFile Image { get; set; }

        [Required]
        [Display(Name = "Medicine Type")]
        public MedicineType MedicineType { get; set; }
    }

    public enum MedicineType
    {
        Miligrams = 1,
        Mililiters = 2,
        Tablets  = 3
    }


}
