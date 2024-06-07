using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using static PZ_Projekt.Controllers.ItemController;

namespace PZ_Projekt.Models
{
    // Model przedmiotu w sklepie internetowym
    public class Item
    {
        // Identyfikator przedmiotu
        public int Id { get; set; }

        // Nazwa przedmiotu, wymagana, maksymalna długość 70 znaków
        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        [StringLength(70, MinimumLength = 1)]
        public string Name { get; set; }

        // Opis przedmiotu, wymagany, maksymalna długość 1000 znaków
        [Required(ErrorMessage = "Pole Opis nie może być puste")]
        [StringLength(1000)]
        public string Description { get; set; }

        // Cena przedmiotu, wymagana, zakres od 1 do 9999
        [Required(ErrorMessage = "Pole Cena nie może być puste")]
        [Range(1, 9999, ErrorMessage = "Cena musi być w zakresie od {1} do {2}.")]
        public decimal Price { get; set; }

        // Kategoria przedmiotu
        public string? Category { get; set; }

        // Ścieżka do zapisanego obrazu na serwerze
        public string? ImageUrl { get; set; }

        // Wymagane zdjęcie (przesyłane przez formularz)
        [Required(ErrorMessage = "Wymagane zdjęcie")]
        [NotMapped]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile ImageFile { get; set; }
    }
}
