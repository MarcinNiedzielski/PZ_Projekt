using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PZ_Projekt.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}