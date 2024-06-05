using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    public class CheckoutViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string DeliveryOption { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
