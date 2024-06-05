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

        [Required]
        public string DeliveryMethod { get; set; } // "Pickup" or "Courier"

        [Required]
        public string Address { get; set; } // Address for delivery

        public List<OrderItem> OrderItems { get; set; }
    }
}

