using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}