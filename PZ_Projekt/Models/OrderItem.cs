using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    // Model pozycji zamówienia w sklepie internetowym
    public class OrderItem
    {
        // Identyfikator pozycji zamówienia
        public int Id { get; set; }

        // Identyfikator zamówienia, do którego należy ta pozycja
        [Required]
        public int OrderId { get; set; }

        // Zamówienie, do którego należy ta pozycja
        public Order Order { get; set; }

        // Identyfikator przedmiotu, który został zamówiony
        [Required]
        public int ItemId { get; set; }

        // Przedmiot, który został zamówiony
        public Item Item { get; set; }

        // Ilość zamówionego przedmiotu
        [Required]
        public int Quantity { get; set; }
    }
}
