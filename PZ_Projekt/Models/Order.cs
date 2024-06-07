using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Metoda dostawy jest wymagana.")]
        public string DeliveryMethod { get; set; } // "Pickup" or "Courier"

        [Required(ErrorMessage = "Adres dostawy jest wymagany.")]
        [StringLength(100)]
        public string Address { get; set; } // Address for delivery

        public string? Status { get; set; } // Status of the order

        public List<OrderItem> OrderItems { get; set; }
    }
}
