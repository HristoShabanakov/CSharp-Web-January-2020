using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lekarna.Models
{
    public class Order
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Medicine { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Discount { get; set; }

        [Required]
        public bool IsTargetReached { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }  

        public virtual ICollection<Pharmacy> Pharmacies { get; set; } 
    }
}
