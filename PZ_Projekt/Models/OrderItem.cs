using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
