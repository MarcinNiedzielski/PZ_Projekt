using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PZ_Projekt.Models
{
    // Model koszyka, przechowuje informacje o przedmiotach w koszyku użytkownika
    public class Cart
    {
        // Identyfikator koszyka
        public int Id { get; set; }

        // Identyfikator użytkownika, do którego przypisany jest koszyk
        public string UserId { get; set; }

        // Lista przedmiotów w koszyku
        public List<CartItem> CartItems { get; set; }
    }
}
