using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PZ_Projekt.Models
{
    // Model elementu koszyka, przechowuje informacje o przedmiocie i jego ilości w koszyku użytkownika
    public class CartItem
    {
        // Identyfikator elementu koszyka
        public int Id { get; set; }

        // Identyfikator przedmiotu
        public int ItemId { get; set; }

        // Referencja do przedmiotu
        public Item Item { get; set; }

        // Ilość danego przedmiotu w koszyku
        [Required]
        public int Quantity { get; set; }

        // Identyfikator użytkownika, do którego przypisany jest koszyk
        [Required]
        public string UserId { get; set; }
    }
}
