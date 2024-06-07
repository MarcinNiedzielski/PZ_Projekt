using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using static PZ_Projekt.Controllers.ItemController;

namespace PZ_Projekt.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole Nazwa nie może być puste")]
        [StringLength(70, MinimumLength = 1)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole Opis nie może być puste")]
        [StringLength(1000)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Pole Cena nie może być puste")]
        [Range(1, 9999, ErrorMessage = "Cena musi być w zakresie od {1} do {2}.")]
        public decimal Price { get; set; }

        public string? Category { get; set; }
        
        public string? ImageUrl { get; set; } // Ścieżka do zapisanego obrazu na serwerze

        [Required(ErrorMessage = "Wymagane zdjęcie")]
        [NotMapped]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile ImageFile { get; set; } // Do przesyłania obrazu przez formularz
    }
}
